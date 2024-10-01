// -----------------------------------------------------------------------
// <copyright file="Slaped.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Scp3114
{
    using Exiled.API.Features;
    using Exiled.Events.Attributes;
    using HarmonyLib;
    using PlayerRoles.PlayableScps.Scp3114;

    /// <summary>
    /// Patches <see cref="Scp3114Slap.DamagePlayers()" />.
    /// Adds the <see cref="Handlers.Scp3114.Slaped" /> event.
    /// </summary>
    [EventPatch(typeof(Handlers.Scp3114), nameof(Handlers.Scp3114.Slaped))]
    [HarmonyPatch(typeof(Scp3114Slap), nameof(Scp3114Slap.DamagePlayers))]
    internal class Slaped
    {
#pragma warning disable SA1313 //arguments should begin with lower-case letter.

        private static void Postfix(Scp3114Slap __instance)
        {
            Handlers.Scp3114.OnSlaped(new(Player.Get(__instance.Owner)));
        }
#pragma warning restore SA1313
    }
}
