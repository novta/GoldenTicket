using Microsoft.AspNetCore.Identity;
using GoldenTicket.Models;

namespace GoldenTicket.ViewModels.Home
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
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public IdentityResult Status { get; set; }

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
