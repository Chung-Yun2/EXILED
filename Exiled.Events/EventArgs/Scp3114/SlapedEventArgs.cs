// -----------------------------------------------------------------------
// <copyright file="SlapedEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Scp3114
{
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;
    using Exiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains all information after SCP-3114 slaped.
    /// </summary>
    public class SlapedEventArgs : IPlayerEvent, IScp3114Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SlapedEventArgs"/> class.
        /// </summary>
        /// <param name="player"><see cref="API.Features.Player"/> who slaped.</param>
        public SlapedEventArgs(Player player)
        {
            Player = player;
            Scp3114 = player.Role.As<Scp3114Role>();
        }

        /// <inheritdoc/>
        public Player Player { get; }

        /// <inheritdoc/>
        public Scp3114Role Scp3114 { get; }
    }
}
