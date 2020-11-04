using GoldenTicket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
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

        private static Country[] _countries = {
            new Country("Afghanistan"),
            new Country("Albania"),
            new Country("Algeria"),
            new Country("American Samoa"),
            new Country("Andorra"),
            new Country("Angola"),
            new Country("Anguilla"),
            new Country("Antarctica"),
            new Country("Antigua and Barbuda"),
            new Country("Argentina"),
            new Country("Armenia"),
            new Country("Aruba"),
            new Country("Australia"),
            new Country("Austria"),
            new Country("Azerbaijan"),
            new Country("Bahamas"),
            new Country("Bahrain"),
            new Country("Bangladesh"),
            new Country("Barbados"),
            new Country("Belarus"),
            new Country("Belgium"),
            new Country("Belize"),
            new Country("Benin"),
            new Country("Bermuda"),
            new Country("Bhutan"),
            new Country("Bolivia"),
            new Country("Bosnia and Herzegovina"),
            new Country("Botswana"),
            new Country("Brazil"),
            new Country("British Indian Ocean Territory"),
            new Country("British Virgin Islands"),
            new Country("Brunei"),
            new Country("Bulgaria"),
            new Country("Burkina Faso"),
            new Country("Burundi"),
            new Country("Cambodia"),
            new Country("Cameroon"),
            new Country("Canada"),
            new Country("Cape Verde"),
            new Country("Cayman Islands"),
            new Country("Central African Republic"),
            new Country("Chad"),
            new Country("Chile"),
            new Country("China"),
            new Country("Christmas Island"),
            new Country("Cocos Islands"),
            new Country("Colombia"),
            new Country("Comoros"),
            new Country("Republic of the Congo"),
            new Country("Democratic Republic of the Congo"),
            new Country("Cook Islands"),
            new Country("Costa Rica"),
            new Country("Croatia"),
            new Country("Cuba"),
            new Country("Curacao"),
            new Country("Cyprus"),
            new Country("Czech Republic"),
            new Country("Denmark"),
            new Country("Djibouti"),
            new Country("Dominica"),
            new Country("Dominican Republic"),
            new Country("East Timor"),
            new Country("Ecuador"),
            new Country("Egypt"),
            new Country("El Salvador"),
            new Country("Equatorial Guinea"),
            new Country("Eritrea"),
            new Country("Estonia"),
            new Country("Ethiopia"),
            new Country("Falkland Islands"),
            new Country("Faroe Islands"),
            new Country("Fiji"),
            new Country("Finland"),
            new Country("France"),
            new Country("French Polynesia"),
            new Country("Gabon"),
            new Country("Gambia"),
            new Country("Georgia"),
            new Country("Germany"),
            new Country("Ghana"),
            new Country("Gibraltar"),
            new Country("Greece"),
            new Country("Greenland"),
            new Country("Grenada"),
            new Country("Guam"),
            new Country("Guatemala"),
            new Country("Guernsey"),
            new Country("Guinea"),
            new Country("Guinea-Bissau"),
            new Country("Guyana"),
            new Country("Haiti"),
            new Country("Honduras"),
            new Country("Hong Kong"),
            new Country("Hungary"),
            new Country("Iceland"),
            new Country("India"),
            new Country("Indonesia"),
            new Country("Iran"),
            new Country("Iraq"),
            new Country("Ireland"),
            new Country("Isle of Man"),
            new Country("Israel"),
            new Country("Italy"),
            new Country("Ivory Coast"),
            new Country("Jamaica"),
            new Country("Japan"),
            new Country("Jersey"),
            new Country("Jordan"),
            new Country("Kazakhstan"),
            new Country("Kenya"),
            new Country("Kiribati"),
            new Country("Kuwait"),
            new Country("Kyrgyzstan"),
            new Country("Laos"),
            new Country("Latvia"),
            new Country("Lebanon"),
            new Country("Lesotho"),
            new Country("Liberia"),
            new Country("Libya"),
            new Country("Liechtenstein"),
            new Country("Lithuania"),
            new Country("Luxembourg"),
            new Country("Macau"),
            new Country("Macedonia"),
            new Country("Madagascar"),
            new Country("Malawi"),
            new Country("Malaysia"),
            new Country("Maldives"),
            new Country("Mali"),
            new Country("Malta"),
            new Country("Marshall Islands"),
            new Country("Mauritania"),
            new Country("Mauritius"),
            new Country("Mayotte"),
            new Country("Mexico"),
            new Country("Micronesia"),
            new Country("Moldova"),
            new Country("Monaco"),
            new Country("Mongolia"),
            new Country("Montenegro"),
            new Country("Montserrat"),
            new Country("Morocco"),
            new Country("Mozambique"),
            new Country("Myanmar"),
            new Country("Namibia"),
            new Country("Nauru"),
            new Country("Nepal"),
            new Country("Netherlands"),
            new Country("Netherlands Antilles"),
            new Country("New Caledonia"),
            new Country("New Zealand"),
            new Country("Nicaragua"),
            new Country("Niger"),
            new Country("Nigeria"),
            new Country("Niue"),
            new Country("Northern Mariana Islands"),
            new Country("North Korea"),
            new Country("Norway"),
            new Country("Oman"),
            new Country("Pakistan"),
            new Country("Palau"),
            new Country("Palestine"),
            new Country("Panama"),
            new Country("Papua New Guinea"),
            new Country("Paraguay"),
            new Country("Peru"),
            new Country("Philippines"),
            new Country("Pitcairn"),
            new Country("Poland"),
            new Country("Portugal"),
            new Country("Puerto Rico"),
            new Country("Qatar"),
            new Country("Reunion"),
            new Country("Romania"),
            new Country("Russia"),
            new Country("Rwanda"),
            new Country("Saint Barthelemy"),
            new Country("Samoa"),
            new Country("San Marino"),
            new Country("Sao Tome and Principe"),
            new Country("Saudi Arabia"),
            new Country("Senegal"),
            new Country("Serbia"),
            new Country("Seychelles"),
            new Country("Sierra Leone"),
            new Country("Singapore"),
            new Country("Sint Maarten"),
            new Country("Slovakia"),
            new Country("Slovenia"),
            new Country("Solomon Islands"),
            new Country("Somalia"),
            new Country("South Africa"),
            new Country("South Korea"),
            new Country("South Sudan"),
            new Country("Spain"),
            new Country("Sri Lanka"),
            new Country("Saint Helena"),
            new Country("Saint Kitts and Nevis"),
            new Country("Saint Lucia"),
            new Country("Saint Martin"),
            new Country("Saint Pierre and Miquelon"),
            new Country("Saint Vincent and the Grenadines"),
            new Country("Sudan"),
            new Country("Suriname"),
            new Country("Svalbard and Jan Mayen"),
            new Country("Swaziland"),
            new Country("Sweden"),
            new Country("Switzerland"),
            new Country("Syria"),
            new Country("Taiwan"),
            new Country("Tajikistan"),
            new Country("Tanzania"),
            new Country("Thailand"),
            new Country("Togo"),
            new Country("Tokelau"),
            new Country("Tonga"),
            new Country("Trinidad and Tobago"),
            new Country("Tunisia"),
            new Country("Turkey"),
            new Country("Turkmenistan"),
            new Country("Turks and Caicos Islands"),
            new Country("Tuvalu"),
            new Country("United Arab Emirates"),
            new Country("Uganda"),
            new Country("United Kingdom"),
            new Country("Ukraine"),
            new Country("Uruguay"),
            new Country("United States"),
            new Country("Uzbekistan"),
            new Country("U.S. Virgin Islands"),
            new Country("Vanuatu"),
            new Country("Vatican"),
            new Country("Venezuela"),
            new Country("Vietnam"),
            new Country("Wallis and Futuna"),
            new Country("Western Sahara"),
            new Country("Yemen"),
            new Country("Zambia"),
            new Country("Zimbabwe"),
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
                await userManager.AddClaimAsync(client, new Claim(CustomClaims.Chair, client.Chair));
            }
            context.Countries.AddRange(_countries);
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