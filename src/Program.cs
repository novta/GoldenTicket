using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GoldenTicket.Data;
using GoldenTicket.Extensions;
using GoldenTicket.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GoldenTicket
{
    /// <summary>
    /// Our program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of program
        /// </summary>
        /// <param name="args">command line arguments</param>
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<GoldenTicketContext>();
                var configuration = services.GetRequiredService<IConfiguration>();
                var userManager = services.GetRequiredService<UserManager<Client>>();
                var roleManager = services.GetService<RoleManager<IdentityRole>>();
                if (configuration.GetValue<bool>("useSeedData"))
                {
                    await SeedData.Initialize(context, userManager, roleManager, configuration);
                }
                else
                {
                    context.Database.Migrate();
                    var role = await roleManager.FindByNameAsync(Role.Administrator);
                    if (role == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(Role.Administrator));
                    }
                }
            }
            host.Run();
        }

        /// <summary>
        /// builds the web host
        /// </summary>
        /// <param name="args">command line arguments</param>
        /// <returns>errors</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddFile("./logs/LogFiles/TechnoDesk/TechnoDesk-" + DateTime.Now.ToUnixTimeStamp() + ".log");
                })
                .UseUrls("http://localhost:5000")
                .UseStartup<Startup>()
                .Build();
    }
}
