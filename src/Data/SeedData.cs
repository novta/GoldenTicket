using GoldenTicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoldenTicket.Data
{
    /// <summary>
    /// Utility for seeding a GoldenTicket Context
    /// </summary>
    public static class SeedData
    {
        private static Client[] _clients = {
            new Client {
                FirstName = "Miroslav",
                LastName = "Novta",
                Title = "Administrator",
                Chair = string.Empty,
                Role = Role.Administrator
            },
            new Client {
                FirstName = "Jaroslav",
                LastName = "Katona",
                Title = "Profesor",
                Chair = "Katedra za Primenjene i Inženjerske Hemije",
                Role = Role.ViceDeanForFinance
            },
            new Client {
                FirstName = "Konte",
                LastName = "Kontic",
                Title = "Profesor",
                Chair = "Biology",
                Role = Role.HeadAccountant
            },
            new Client {
                FirstName = "Senka",
                LastName = "Seveca",
                Title = "Profesor",
                Chair = "Mathematics",
                Role = Role.SecretaryOfScientificTeachingCouncil
            },
            new Client {
                FirstName = "Seka",
                LastName = "Sekatedre",
                Title = "Profesor",
                Chair = "Philosophy",
                Role = Role.SecretaryOfChair
            },
            new Client {
                FirstName = "Mali",
                LastName = "Kontic",
                Title = "Profesor",
                Chair = "Fluids",
                Role = Role.FinanceOfficer
            },
            new Client {
                FirstName = "Taryn",
                LastName = "Norman",
                Title = "Profesor",
                Chair = "Technic",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Kieran",
                LastName = "Lam",
                Title = "Profesor",
                Chair = "Something",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Natalya",
                LastName = "Lynch",
                Title = "Profesor",
                Chair = "Chamistry1",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Gavin",
                LastName = "Preston",
                Title = "Profesor",
                Chair = "Chamistry2",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Kira",
                LastName = "Paul",
                Title = "Profesor",
                Chair = "Chamistry3",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Shyla",
                LastName = "Turner",
                Title = "Profesor",
                Chair = "Chamistry4",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Ana",
                LastName = "Wise",
                Title = "Profesor",
                Chair = "Chamistry5",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Rylan",
                LastName = "Bryan",
                Title = "Profesor",
                Chair = "Chamistry6",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Cailyn",
                LastName = "Melton",
                Title = "Profesor",
                Chair = "Chamistry7",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Rory",
                LastName = "Clark",
                Title = "Profesor",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Elizebeth",
                LastName = "Salgado",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Maddie",
                LastName = "Streater",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Chrissy",
                LastName = "Noffsinger",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Eufemia",
                LastName = "Max",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Teresa",
                LastName = "Honea",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Kendrick",
                LastName = "Haydon",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Napoleon",
                LastName = "Bernardo",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Jule",
                LastName = "Rigdon",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Michaela",
                LastName = "Spady",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Derek",
                LastName = "Raley",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Lindsy",
                LastName = "Messineo",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Reggie",
                LastName = "Strohm",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Sheilah",
                LastName = "Troia",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Vivien",
                LastName = "Modesto",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            },
            new Client {
                FirstName = "Evia",
                LastName = "Days",
                Title = "Assistent",
                Chair = "Chamistry8",
                Role = Role.Employee
            }
        };

        /// <summary>
        /// Initializes the ticket system with data
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="userManager">admin</param>
        /// <param name="roleManager"></param>
        /// <param name="configuration">IConfiguration reference</param>
        public static async Task Initialize(GoldenTicketContext context, UserManager<Client> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var randGenerator = new Random();

            foreach (var role in Role.AllRoles)
            {
                var administratorRole = await roleManager.FindByNameAsync(role);
                if (administratorRole == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            foreach (var client in _clients)
            {
                client.DateAdded = DateTime.Now.AddMonths(randGenerator.Next(-36, -25));
                client.UserName = $"{client.FirstName.ToLower()}.{client.LastName.ToLower()}";
                await userManager.CreateAsync(client, configuration["adminPassword"]);
                await userManager.AddToRoleAsync(client, client.Role);
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