using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the client
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// The date that the client was added to the system
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        /// The last name of the Moderator
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        /// <summary>
        /// The last name of the Moderator
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Chair { get; set; }

        /// <summary>
        /// Gets or sets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        [Required]
        [MaxLength(50)]
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
            this.Email = client.Email;
            this.EmailConfirmed = client.EmailConfirmed;
            this.PhoneNumber = client.PhoneNumber;
            this.PhoneNumberConfirmed = client.PhoneNumberConfirmed;
            this.FirstName = client.FirstName;
            this.LastName = client.LastName;
            this.DateAdded = client.DateAdded;
            this.Title = client.Title;
            this.Chair = client.Chair;
            this.Role = client.Role;
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetRoles()
        {
            var result = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = Data.Role.Employee,
                    Value = Data.Role.Employee,
                },
                new SelectListItem
                {
                    Text = Data.Role.FinanceOfficer,
                    Value = Data.Role.FinanceOfficer,
                },
                new SelectListItem
                {
                    Text = Data.Role.SecretaryOfChair,
                    Value = Data.Role.SecretaryOfChair,
                },
                new SelectListItem
                {
                    Text = Data.Role.SecretaryOfScientificTeachingCouncil,
                    Value = Data.Role.SecretaryOfScientificTeachingCouncil,
                },
                new SelectListItem
                {
                    Text = Data.Role.HeadAccountant,
                    Value = Data.Role.HeadAccountant,
                },
                new SelectListItem
                {
                    Text = Data.Role.ViceDeanForFinance,
                    Value = Data.Role.ViceDeanForFinance,
                },
                new SelectListItem
                {
                    Text = Data.Role.Administrator,
                    Value = Data.Role.Administrator,
                }
            };
            if (!string.IsNullOrWhiteSpace(Role))
            {
                foreach (var item in result)
                {
                    if (item.Text == Role)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            return result;
        }
    }
}