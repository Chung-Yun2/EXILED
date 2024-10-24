// -----------------------------------------------------------------------
// <copyright file="UpdateLungingEventArgs.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Scp939
{
    using Exiled.API.Features;
    using Exiled.API.Features.Roles;
    using Exiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains all information when SCP-939 uses its lunge ability.
    /// </summary>
    public class UpdateLungingEventArgs : IPlayerEvent, IScp939Event, IDeniableEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateLungingEventArgs"/> class.
        /// </summary>
        /// <param name="player"><see cref="Exiled.API.Features.Player"/> who uses its lunge ability.</param>
        public UpdateLungingEventArgs(Player player)
        {
            IsAllowed = true;
            Player = player;
            Scp939 = player.Role.As<Scp939Role>();
        }

        /// <inheritdoc/>
        public bool IsAllowed { get; set; }

        /// <inheritdoc/>
        public Player Player { get; }

        /// <inheritdoc/>
        public Scp939Role Scp939 { get; }
    }
}
