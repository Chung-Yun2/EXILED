// -----------------------------------------------------------------------
// <copyright file="UpdateLunging.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Scp939
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;

    using Exiled.API.Features;
    using Exiled.API.Features.Pools;
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Scp939;
    using HarmonyLib;
    using PlayerRoles.PlayableScps.Scp939;
    using PlayerRoles.Subroutines;

    using static HarmonyLib.AccessTools;

    /// <summary>
    /// Patches <see cref="Scp939Motor.GetFrameMove()"/>
    /// to add <see cref="UpdateLunging"/> event.
    /// </summary>
    [EventPatch(typeof(Handlers.Scp939), nameof(Handlers.Scp939.UpdateLunging))]
    [HarmonyPatch(typeof(Scp939Motor), nameof(Scp939Motor.GetFrameMove))]
    internal class UpdateLunging
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            List<CodeInstruction> newInstructions = ListPool<CodeInstruction>.Pool.Get(instructions);

            Label returnLabel = generator.DefineLabel();
            Label skipPatchCode = generator.DefineLabel();

            int returnIndex = newInstructions.FindLastIndex(i => i.Calls(Method(typeof(Scp939LungeAbility), nameof(Scp939LungeAbility.ClientSendHit)))) - 3;
            newInstructions[returnIndex].WithLabels(returnLabel);

            newInstructions.InsertRange(
                0, new CodeInstruction[]
                {
                    new(OpCodes.Ldarg_0),

                    new(OpCodes.Call, PropertyGetter(typeof(Scp939Motor), nameof(Scp939Motor.IsLunging))),

                    new(OpCodes.Brfalse_S, skipPatchCode),

                    new(OpCodes.Ldarg_0),

                    new(OpCodes.Ldfld, Field(typeof(Scp939Motor), nameof(Scp939Motor._lunge))),

                    new(OpCodes.Callvirt, PropertyGetter(typeof(KeySubroutine<Scp939Role>), nameof(KeySubroutine<Scp939Role>.Owner))),

                    new(OpCodes.Call, Method(typeof(Player), nameof(Player.Get), new[]
                    {
                        typeof(ReferenceHub),
                    })),

                    new(OpCodes.Newobj, GetDeclaredConstructors(typeof(UpdateLungingEventArgs))[0]),
                    new(OpCodes.Dup),

                    new(OpCodes.Call, Method(typeof(Handlers.Scp939), nameof(Handlers.Scp939.OnUpdateLunging))),

                    new(OpCodes.Callvirt, PropertyGetter(typeof(UpdateLungingEventArgs), nameof(UpdateLungingEventArgs.IsAllowed))),

                    new(OpCodes.Brfalse_S, returnLabel),

                    new CodeInstruction(OpCodes.Nop).WithLabels(skipPatchCode),
                });

            for (int z = 0; z < newInstructions.Count; z++)
                yield return newInstructions[z];

            ListPool<CodeInstruction>.Pool.Return(newInstructions);
        }
    }
}
