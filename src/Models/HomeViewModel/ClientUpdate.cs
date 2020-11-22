﻿namespace GoldenTicket.Models.HomeViewModel
{
    /// <summary>
    /// ClientUpdate is a view model to allow client self info update and password change
    /// </summary>
    /// <seealso cref="GoldenTicket.Models.Client" />
    public class ClientUpdate : Client
    {
        /// <summary>
        /// The current password
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// The new password
        /// </summary>
        public string NewPassword { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientUpdate"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public ClientUpdate(Client client) : base(client)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientUpdate"/> class.
        /// </summary>
        public ClientUpdate() : base()
        {
        }
    }
}
