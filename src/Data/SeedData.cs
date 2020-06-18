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
        private static Moderator[] _moderators = {
            new Moderator {
                FirstName = "Madeline",
                LastName = "Booth",
                Title = "Profesor",
                Chair = "Chamistry",
                IsAdmin = true
            },
            new Moderator {
                FirstName = "Charles",
                LastName = "Woods",
                Title = "Profesor",
                Chair = "Biology",
                IsAdmin = true
            },
            new Moderator {
                FirstName = "Nico",
                LastName = "Perkins",
                Title = "Profesor",
                Chair = "Mathematics",
                IsAdmin = true
            },
            new Moderator {
                FirstName = "Marie",
                LastName = "Wilson",
                Title = "Profesor",
                Chair = "Philosophy",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Nancy",
                LastName = "Mays",
                Title = "Profesor",
                Chair = "Fluids",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Taryn",
                LastName = "Norman",
                Title = "Profesor",
                Chair = "Technic",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Kieran",
                LastName = "Lam",
                Title = "Profesor",
                Chair = "Something",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Natalya",
                LastName = "Lynch",
                Title = "Profesor",
                Chair = "Chamistry1",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Gavin",
                LastName = "Preston",
                Title = "Profesor",
                Chair = "Chamistry2",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Kira",
                LastName = "Paul",
                Title = "Profesor",
                Chair = "Chamistry3",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Shyla",
                LastName = "Turner",
                Title = "Profesor",
                Chair = "Chamistry4",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Ana",
                LastName = "Wise",
                Title = "Profesor",
                Chair = "Chamistry5",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Rylan",
                LastName = "Bryan",
                Title = "Profesor",
                Chair = "Chamistry6",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Cailyn",
                LastName = "Melton",
                Title = "Profesor",
                Chair = "Chamistry7",
                IsAdmin = false
            },
            new Moderator {
                FirstName = "Rory",
                LastName = "Clark",
                Title = "Profesor",
                Chair = "Chamistry8",
                IsAdmin = false
            }
        };

        private static Client[] _clients = {
            new Client {
                Address = "19 Nicolls Court Rego Park, NY 11374",
                Company = "Openlane",
                EmailAddress = "Openlane",
                FirstName = "Elizebeth",
                LastName = "Salgado",
                PhoneNumber = "(738) 531-3531"
            },
            new Client {
                Address = "14 Front St. Winston Salem, NC 27103",
                Company = "Yearin",
                EmailAddress = "Yearin",
                FirstName = "Maddie",
                LastName = "Streater",
                PhoneNumber = "(485) 563-0017"
            },
            new Client {
                Address = "12 Galvin Lane Snohomish, WA 98290",
                Company = "Goodsilron",
                EmailAddress = "Goodsilron",
                FirstName = "Chrissy",
                LastName = "Noffsinger",
                PhoneNumber = "(755) 616-9245"
            },
            new Client {
                Address = "9 Honey Creek Road Victoria, TX 77904",
                Company = "Condax",
                EmailAddress = "Condax",
                FirstName = "Eufemia",
                LastName = "Max",
                PhoneNumber = "(637) 949-5699"
            },
            new Client {
                Address = "791 West Lower River Street Peabody, MA 01960",
                Company = "Opentech",
                EmailAddress = "Opentech",
                FirstName = "Teresa",
                LastName = "Honea",
                PhoneNumber = "(469) 853-6224"
            },
            new Client {
                Address = "67 Blue Spring St. Hillsboro, OR 97124",
                Company = "Golddex",
                EmailAddress = "Golddex",
                FirstName = "Kendrick",
                LastName = "Haydon",
                PhoneNumber = "(695) 261-7236"
            },
            new Client {
                Address = "61 Old Buttonwood Drive Grand Rapids, MI 49503",
                Company = "year-job",
                EmailAddress = "year-job",
                FirstName = "Napoleon",
                LastName = "Bernardo",
                PhoneNumber = "(205) 749-6785"
            },
            new Client {
                Address = "769 Elizabeth St. Greenfield, IN 46140",
                Company = "Isdom",
                EmailAddress = "Isdom",
                FirstName = "Jule",
                LastName = "Rigdon",
                PhoneNumber = "(295) 676-0045"
            },
            new Client {
                Address = "8728 Clay Ave. New City, NY 10956",
                Company = "Gogozoom",
                EmailAddress = "Gogozoom",
                FirstName = "Michaela",
                LastName = "Spady",
                PhoneNumber = "(684) 255-3602"
            },
            new Client {
                Address = "95 Wayne St. Reno, NV 89523",
                Company = "Y-corporation",
                EmailAddress = "Y-corporation",
                FirstName = "Derek",
                LastName = "Raley",
                PhoneNumber = "(366) 249-6137"
            },
            new Client {
                Address = "444 Saxon Court Deland, FL 32720",
                Company = "Nam-zim",
                EmailAddress = "Nam-zim",
                FirstName = "Lindsy",
                LastName = "Messineo",
                PhoneNumber = "(292) 765-7653"
            },
            new Client {
                Address = "9931 Roberts Ave. Columbus, GA 31904",
                Company = "Donquadtech",
                EmailAddress = "Donquadtech",
                FirstName = "Reggie",
                LastName = "Strohm",
                PhoneNumber = "(313) 365-0177"
            },
            new Client {
                Address = "611 Oakwood Rd. Hudson, NH 03051",
                Company = "Warephase",
                EmailAddress = "Warephase",
                FirstName = "Sheilah",
                LastName = "Troia",
                PhoneNumber = "(366) 970-8567"
            },
            new Client {
                Address = "210C Snake Hill Street Ambler, PA 19002",
                Company = "Donware",
                EmailAddress = "Donware",
                FirstName = "Vivien",
                LastName = "Modesto",
                PhoneNumber = "(725) 774-7198"
            },
            new Client {
                Address = "287 Grand St. North Olmsted, OH 44070",
                Company = "Faxquote",
                EmailAddress = "Faxquote",
                FirstName = "Evia",
                LastName = "Days",
                PhoneNumber = "(764) 373-1146"
            }
        };

        /// <summary>
        /// Initializes the ticket system with data
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="userManager">admin</param>
        /// <param name="roleManager"></param>
        public static void Initialize(GoldenTicketContext context, UserManager<Moderator> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            var randGenerator = new Random();

            foreach (var client in _clients)
            {
                client.DateAdded = DateTime.Now.AddMonths(randGenerator.Next(-24, -12));
            }

            var role = roleManager.FindByNameAsync(DataConstants.AdministratorRole).Result;
            if (role == null)
            {
                roleManager.CreateAsync(new IdentityRole(DataConstants.AdministratorRole));
            }

            foreach (var moderator in _moderators)
            {
                moderator.DateAdded = DateTime.Now.AddMonths(randGenerator.Next(-36, -25));
                moderator.UserName = $"{moderator.FirstName}.{moderator.LastName}";
                userManager.CreateAsync(moderator, "password").Wait();
                if (moderator.IsAdmin)
                {
                    userManager.AddToRoleAsync(moderator, DataConstants.AdministratorRole);
                }
            }

            context.Clients.AddRange(_clients);

            context.SaveChanges();

            foreach (var client in context.Clients)
            {
                var ticketCount = randGenerator.Next(0, 15);
                for (var i = 0; i < ticketCount; i++)
                {
                    context.Tickets.Add(new Ticket
                    {
                        ClientId = client.Id,
                        Title = $"{client.Company}: Case {i}",
                        Description = $"Super awesome ticket {i}",
                        Complexity = i % 3 + 1,
                        IsUrgent = randGenerator.Next(0, 5) == 0,
                        Notes = "Terrible client to work with",
                        Open = randGenerator.Next(0, 2) == 0,
                        DateAdded = DateTime.Now.AddMonths(randGenerator.Next(-24, -12))
                    });
                }
            }

            context.SaveChanges();

            foreach (var ticket in context.Tickets)
            {
                var workTimesCount = randGenerator.Next(0, 10);
                for (var i = 0; i < workTimesCount; i++)
                {
                    var start = ticket.DateAdded.AddHours(randGenerator.Next(1, 60));
                    var end = start.AddMinutes(randGenerator.Next(15, 60));
                    context.TechnicianTicketTimes.Add(new TechnicianTicketTime
                    {
                        Start = start,
                        End = end,
                        TechnicianId = context.Users.OrderBy(t => Guid.NewGuid()).Take(1).First().UserName,
                        TicketId = ticket.Id
                    });
                }
            }

            context.SaveChanges();
        }
    }
}