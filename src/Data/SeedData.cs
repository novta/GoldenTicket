using GoldenTicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GoldenTicket.Data
{
    /// <summary>
    /// Utility for seeding a GoldenTicket Context
    /// </summary>
    public static class SeedData
    {
        private static Client[] _clients = {
            new Client {
                FirstName = "Jaroslav",
                LastName = "Katona",
                Title = "Profesor",
                Chair = "Katedra za Primenjene i Inženjerske Hemije",
                IsModerator = true,
                IsAdmin = true
            },
            //new Client {
            //    FirstName = "Charles",
            //    LastName = "Woods",
            //    Title = "Profesor",
            //    Chair = "Biology",
            //    IsModerator = true,
            //    IsAdmin = true
            //},
            //new Client {
            //    FirstName = "Nico",
            //    LastName = "Perkins",
            //    Title = "Profesor",
            //    Chair = "Mathematics",
            //    IsModerator = true,
            //    IsAdmin = true
            //},
            //new Client {
            //    FirstName = "Marie",
            //    LastName = "Wilson",
            //    Title = "Profesor",
            //    Chair = "Philosophy",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Nancy",
            //    LastName = "Mays",
            //    Title = "Profesor",
            //    Chair = "Fluids",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Taryn",
            //    LastName = "Norman",
            //    Title = "Profesor",
            //    Chair = "Technic",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Kieran",
            //    LastName = "Lam",
            //    Title = "Profesor",
            //    Chair = "Something",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Natalya",
            //    LastName = "Lynch",
            //    Title = "Profesor",
            //    Chair = "Chamistry1",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Gavin",
            //    LastName = "Preston",
            //    Title = "Profesor",
            //    Chair = "Chamistry2",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Kira",
            //    LastName = "Paul",
            //    Title = "Profesor",
            //    Chair = "Chamistry3",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Shyla",
            //    LastName = "Turner",
            //    Title = "Profesor",
            //    Chair = "Chamistry4",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Ana",
            //    LastName = "Wise",
            //    Title = "Profesor",
            //    Chair = "Chamistry5",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Rylan",
            //    LastName = "Bryan",
            //    Title = "Profesor",
            //    Chair = "Chamistry6",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Cailyn",
            //    LastName = "Melton",
            //    Title = "Profesor",
            //    Chair = "Chamistry7",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Rory",
            //    LastName = "Clark",
            //    Title = "Profesor",
            //    Chair = "Chamistry8",
            //    IsModerator = true,
            //    IsAdmin = false
            //},
            //new Client {
            //    FirstName = "Elizebeth",
            //    LastName = "Salgado",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Maddie",
            //    LastName = "Streater",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Chrissy",
            //    LastName = "Noffsinger",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Eufemia",
            //    LastName = "Max",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Teresa",
            //    LastName = "Honea",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Kendrick",
            //    LastName = "Haydon",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Napoleon",
            //    LastName = "Bernardo",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Jule",
            //    LastName = "Rigdon",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Michaela",
            //    LastName = "Spady",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Derek",
            //    LastName = "Raley",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Lindsy",
            //    LastName = "Messineo",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Reggie",
            //    LastName = "Strohm",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Sheilah",
            //    LastName = "Troia",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Vivien",
            //    LastName = "Modesto",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //},
            //new Client {
            //    FirstName = "Evia",
            //    LastName = "Days",
            //    Title = "Assistent",
            //    Chair = "Chamistry8",
            //}
        };

        /// <summary>
        /// Initializes the ticket system with data
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="userManager">admin</param>
        /// <param name="roleManager"></param>
        public static void Initialize(GoldenTicketContext context, UserManager<Client> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var randGenerator = new Random();

            var administratorRole = roleManager.FindByNameAsync(DataConstants.AdministratorRole).Result;
            if (administratorRole == null)
            {
                roleManager.CreateAsync(new IdentityRole(DataConstants.AdministratorRole));
            }
            foreach (var client in _clients)
            {
                client.DateAdded = DateTime.Now.AddMonths(randGenerator.Next(-36, -25));
                client.UserName = $"{client.FirstName.ToLower()}.{client.LastName.ToLower()}";
                userManager.CreateAsync(client, "password").Wait();
                if (client.IsAdmin)
                {
                    userManager.AddToRoleAsync(client, DataConstants.AdministratorRole);
                }
            }
            //context.Clients.AddRange(_clients);
            context.SaveChanges();

            //foreach (var client in context.Clients)
            //{
            //    var ticketCount = randGenerator.Next(0, 15);
            //    for (var i = 0; i < ticketCount; i++)
            //    {
            //        context.Tickets.Add(new Ticket
            //        {
            //            ClientId = client.Id,
            //            Title = client.Title,
            //            Description = $"Super awesome ticket {i}",
            //            IsUrgent = randGenerator.Next(0, 5) == 0,
            //            Notes = "Terrible client to work with",
            //            Open = randGenerator.Next(0, 2) == 0,
            //            DateAdded = DateTime.Now.AddMonths(randGenerator.Next(-24, -12))
            //        });
            //    }
            //}
            //context.SaveChanges();

            //foreach (var ticket in context.Tickets)
            //{
            //    var workTimesCount = randGenerator.Next(0, 10);
            //    for (var i = 0; i < workTimesCount; i++)
            //    {
            //        var start = ticket.DateAdded.AddHours(randGenerator.Next(1, 60));
            //        context.TicketReviews.Add(new TicketReview
            //        {
            //            Timestamp = start,
            //            Outcome = Review.Approved,
            //            ModeratorId = context.Users.OrderBy(t => Guid.NewGuid()).Take(1).First().UserName,
            //            TicketId = ticket.Id
            //        });
            //    }
            //}
            //context.SaveChanges();
        }
    }
}