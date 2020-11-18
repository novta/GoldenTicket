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
            new Country("Авганистан"),
            new Country("Азербејџан"),
            new Country("Албанија"),
            new Country("Алжир"),
            new Country("Ангола"),
            new Country("Андора"),
            new Country("Антигва и Барбуда"),
            new Country("Аргентина"),
            new Country("Аустралија"),
            new Country("Аустрија"),
            new Country("Бангладеш"),
            new Country("Барбадос"),
            new Country("Бахаме"),
            new Country("Бахреин"),
            new Country("Белгија"),
            new Country("Белизе"),
            new Country("Белорусија"),
            new Country("Бенин"),
            new Country("Боливија"),
            new Country("Босна и Херцеговина"),
            new Country("Боцвана"),
            new Country("Бразил"),
            new Country("Брунеј"),
            new Country("Бугарска"),
            new Country("Буркина Фасо"),
            new Country("Бурунди"),
            new Country("Бутан"),
            new Country("Вануату"),
            new Country("Ватикан"),
            new Country("Венецуела"),
            new Country("Вијетнам"),
            new Country("Габон"),
            new Country("Гамбија"),
            new Country("Гана"),
            new Country("Гвајана"),
            new Country("Гватемала"),
            new Country("Гвинеја Бисао"),
            new Country("Гвинеја"),
            new Country("Гренада"),
            new Country("Грузија"),
            new Country("Грчка"),
            new Country("Данска"),
            new Country("Демократска Република Конго"),
            new Country("Доминика"),
            new Country("Доминиканска Република"),
            new Country("Египат"),
            new Country("Еквадор"),
            new Country("Екваторијална Гвинеја"),
            new Country("Еритреја"),
            new Country("Естонија"),
            new Country("Етиопија"),
            new Country("Замбија"),
            new Country("Зеленортска Острва"),
            new Country("Зимбабве"),
            new Country("Израел"),
            new Country("Индија"),
            new Country("Индонезија"),
            new Country("Ирак"),
            new Country("Иран"),
            new Country("Исланд"),
            new Country("Источни Тимор"),
            new Country("Италија"),
            new Country("Јамајка"),
            new Country("Јапан"),
            new Country("Јемен"),
            new Country("Јерменија"),
            new Country("Јордан"),
            new Country("Јужна Кореја"),
            new Country("Јужни Судан"),
            new Country("Јужноафричка Република"),
            new Country("Казахстан"),
            new Country("Камбоџа"),
            new Country("Камерун"),
            new Country("Канада"),
            new Country("Катар"),
            new Country("Кенија"),
            new Country("Кина"),
            new Country("Кипар"),
            new Country("Киргистан"),
            new Country("Кирибати"),
            new Country("Колумбија"),
            new Country("Комори"),
            new Country("Костарика"),
            new Country("Куба"),
            new Country("Кувајт"),
            new Country("Лаос"),
            new Country("Лесото"),
            new Country("Летонија"),
            new Country("Либан"),
            new Country("Либерија"),
            new Country("Либија"),
            new Country("Литванија"),
            new Country("Лихтенштајн"),
            new Country("Луксембург"),
            new Country("Мадагаскар"),
            new Country("Мађарска"),
            new Country("Малави"),
            new Country("Малдиви"),
            new Country("Малезија"),
            new Country("Мали"),
            new Country("Малта"),
            new Country("Мароко"),
            new Country("Маршалска Острва"),
            new Country("Мауританија"),
            new Country("Маурицијус"),
            new Country("Мексико"),
            new Country("Микронезија"),
            new Country("Мјанмар"),
            new Country("Мозамбик"),
            new Country("Молдавија"),
            new Country("Монако"),
            new Country("Монголија"),
            new Country("Намибија"),
            new Country("Науру"),
            new Country("Немачка"),
            new Country("Непал"),
            new Country("Нигер"),
            new Country("Нигерија"),
            new Country("Никарагва"),
            new Country("Нови Зеланд"),
            new Country("Норвешка"),
            new Country("Обала Слоноваче"),
            new Country("Оман"),
            new Country("Пакистан"),
            new Country("Палау"),
            new Country("Панама"),
            new Country("Папуа Нова Гвинеја"),
            new Country("Парагвај"),
            new Country("Перу"),
            new Country("Пољска"),
            new Country("Португалија"),
            new Country("Република Ирска"),
            new Country("Република Конго"),
            new Country("Руанда"),
            new Country("Румунија"),
            new Country("Русија"),
            new Country("Салвадор"),
            new Country("Самоа"),
            new Country("Сан Марино"),
            new Country("Сао Томе и Принципе"),
            new Country("Саудијска Арабија"),
            new Country("Свазиленд"),
            new Country("Света Луција"),
            new Country("Свети Винсент и Гренадини"),
            new Country("Северна Кореја"),
            new Country("Северна Македонија"),
            new Country("Сејшелска Острва"),
            new Country("Сенегал"),
            new Country("Сент Китс и Невис"),
            new Country("Сијера Леоне"),
            new Country("Сингапур"),
            new Country("Сирија"),
            new Country("Сједињене Америчке Државе"),
            new Country("Словачка"),
            new Country("Словенија"),
            new Country("Соломонова Острва"),
            new Country("Сомалија"),
            new Country("Србија"),
            new Country("Судан"),
            new Country("Суринам"),
            new Country("Тајланд"),
            new Country("Танзанија"),
            new Country("Таџикистан"),
            new Country("Того"),
            new Country("Тонга"),
            new Country("Тринидад и Тобаго"),
            new Country("Тувалу"),
            new Country("Тунис"),
            new Country("Туркменистан"),
            new Country("Турска"),
            new Country("Уганда"),
            new Country("Узбекистан"),
            new Country("Уједињени Арапски Емирати"),
            new Country("Уједињено Краљевство"),
            new Country("Украјина"),
            new Country("Уругвај"),
            new Country("Филипини"),
            new Country("Финска"),
            new Country("Фиџи"),
            new Country("Француска"),
            new Country("Хаити"),
            new Country("Холандија"),
            new Country("Хондурас"),
            new Country("Хрватска"),
            new Country("Централноафричка Република"),
            new Country("Црна Гора"),
            new Country("Чад"),
            new Country("Чешка"),
            new Country("Чиле"),
            new Country("Џибути"),
            new Country("Швајцарска"),
            new Country("Шведска"),
            new Country("Шпанија"),
            new Country("Шри Ланка"),
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