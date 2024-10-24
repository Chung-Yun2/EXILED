// -----------------------------------------------------------------------
// <copyright file="AttackedEventArgs.cs" company="Exiled Team">
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
    /// Contains all information after SCP-096 trigger his attack ability.
    /// </summary>
    public class AttackedEventArgs : IPlayerEvent, IScp096Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttackedEventArgs"/> class.
        /// </summary>
        /// <param name="player"><see cref="API.Features.Player"/> who triggered ability.</param>
        public AttackedEventArgs(Player player)
        {
            Player = player;
            Scp096 = player.Role.As<Scp096Role>();
        }

        /// <inheritdoc/>
        public Scp096Role Scp096 { get; }

        /// <inheritdoc/>
        public Player Player { get; }
    }
}
