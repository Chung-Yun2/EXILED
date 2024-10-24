// -----------------------------------------------------------------------
// <copyright file="Attacked.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Scp096
{
    using Exiled.Events.Attributes;
    using Exiled.Events.Handlers;
    using HarmonyLib;
    using PlayerRoles.PlayableScps.Scp096;

    /// <summary>
    /// Patches <see cref="Scp096AttackAbility.ServerProcessCmd(Mirror.NetworkReader)" />.
    /// Adds the <see cref="Scp096.Attacked" /> event.
    /// </summary>
    [EventPatch(typeof(Scp096), nameof(Scp096.Attacked))]
    [HarmonyPatch(typeof(Scp096AttackAbility), nameof(Scp096AttackAbility.ServerProcessCmd))]
    internal class Attacked
    {
#pragma warning disable SA1313 //arguments should begin with lower-case letter.

        private static void Postfix(Scp096AttackAbility __instance)
        {
            Scp096.OnAttacked(new(API.Features.Player.Get(__instance.Owner)));
        }
#pragma warning restore SA1313
    }
}
