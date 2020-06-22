// -----------------------------------------------------------------------
// <copyright file="EscapingPocketDimensionEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs
{
    using System;
    using Exiled.API.Features;
    using UnityEngine;

    /// <summary>
    /// Contains all informations before a player dies from walking through the incorrect exit in the pocket dimension.
    /// </summary>
    public class FailedEscapePocketDimensionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedEscapePocketDimensionEventArgs"/> class.
        /// </summary>
        /// <param name="player"><inheritdoc cref="Player"/></param>
        /// <param name="teleporter"><inheritdoc cref="Teleporter"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public FailedEscapePocketDimensionEventArgs(Player player, PocketDimensionTeleport teleporter, bool isAllowed = true)
        {
            Player = player;
            Teleporter = teleporter;
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets the player who's escaping the pocket dimension.
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// Gets the PocketDimensionTeleport the player walked into.
        /// </summary>
        public PocketDimensionTeleport Teleporter { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the event can be executed or not.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}
