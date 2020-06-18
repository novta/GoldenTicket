using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GoldenTicket.Models
{
    /// <summary>
    /// A Moderator and information
    /// </summary>
    public class Moderator : IdentityUser
    {
        /// <summary>
        /// Is the Moderator an Admin?
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// The first name of the Moderator
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the Moderator
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The last name of the Moderator
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The last name of the Moderator
        /// </summary>
        public string Chair { get; set; }

        /// <summary>
        /// The Date the Moderator was hired
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// Gets pay rate for this Moderator
        /// </summary>
        /// <returns>Pay rate</returns>
        public int GetPayRate()
        {
            return 30 + 10 * (int)((DateTime.Now - DateAdded).TotalDays / 365);
        }
    }
}
