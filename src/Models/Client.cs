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
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public string Role { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        public Client()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public Client(Client client) 
            : base(client.UserName)
        {
            this.Id = client.Id;
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.DateAdded = client.DateAdded;
            this.Title = client.Title;
            this.Chair = client.Chair;
            this.Role = client.Role;
        }

        /// <summary>
        /// Shallows the copy.
        /// </summary>
        /// <returns>Returns a ShallowCopy of object.</returns>
        public Client ShallowCopy()
        {
            return (Client)this.MemberwiseClone();
        }
    }
}