using Microsoft.AspNetCore.Identity;
using System;

namespace GoldenTicket.Models
{
    /// <summary>
    /// A client and their related information
    /// </summary>
    public class Client : IdentityUser
    {
        /// <summary>
        /// The first name of the client
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the client
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The date that the client was added to the system
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// The last name of the Moderator
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The last name of the Moderator
        /// </summary>
        public string Chair { get; set; }

        /// <summary>
        /// Is the Moderator
        /// </summary>
        public bool IsModerator { get; set; }

        /// <summary>
        /// Is the Admin
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}