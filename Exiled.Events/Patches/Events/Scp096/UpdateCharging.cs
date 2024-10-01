// -----------------------------------------------------------------------
// <copyright file="UpdateCharging.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Scp096
{
    using Exiled.API.Features;
    using Exiled.Events.Attributes;
    using HarmonyLib;
    using PlayerRoles.PlayableScps.Scp096;

    /// <summary>
    /// Patches <see cref="Scp096CharacterModel.Update()" />.
    /// Adds the <see cref="Handlers.Scp096.UpdateCharging" /> event.
    /// </summary>
    [EventPatch(typeof(Handlers.Scp096), nameof(Handlers.Scp096.UpdateCharging))]
    [HarmonyPatch(typeof(Scp096CharacterModel), nameof(Scp096CharacterModel.Update))]
    internal class UpdateCharging
    {
#pragma warning disable SA1313 //arguments should begin with lower-case letter.

        private static void Postfix(Scp096CharacterModel __instance)
        {
            if (__instance._rageAbility == null || !__instance._role.IsAbilityState(Scp096AbilityState.Charging))
                return;

            Handlers.Scp096.OnUpdateCharging(new(Player.Get(__instance.OwnerHub)));
        }
    }
}
#pragma warning restore SA1313