// -----------------------------------------------------------------------
// <copyright file="UpdateChargingEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Scp096
{
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;
    using Exiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains all information when SCP-096 charges.
    /// </summary>
    public class UpdateChargingEventArgs : IPlayerEvent, IScp096Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateChargingEventArgs"/> class.
        /// </summary>
        /// <param name="player"><see cref="Exiled.API.Features.Player"/> who charges.</param>
        public UpdateChargingEventArgs(Player player)
        {
            Player = player;
            Scp096 = player.Role.As<Scp096Role>();
        }

        /// <inheritdoc/>
        public Player Player { get; }

        /// <inheritdoc/>
        public Scp096Role Scp096 { get; }
    }
}
