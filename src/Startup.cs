using GoldenTicket.Data;
using GoldenTicket.EmailHelper;
using GoldenTicket.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace GoldenTicket
{
    /// <summary>
    /// The class for starting the application. Gets the HostingEnvironment and Configuration
    /// </summary>
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment { get; set; }

        private IConfiguration _configuration { get; set; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="env">The hosting environment</param>
        /// <param name="config">The configuration settings for the application</param>
        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            _hostingEnvironment = env;
            _configuration = config;
        }

        /// <summary>
        /// Configures the services for this application
        /// </summary>
        /// <param name="services">The service container for this application</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.Configure<EmailSettings>(_configuration.GetSection("EmailSettings"));
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.AddDbContext<GoldenTicketContext>(options => options.UseSqlite(_configuration["connectionString"]));

            services.AddIdentity<Client, IdentityRole>().AddEntityFrameworkStores<GoldenTicketContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("sr-Cyrl"),
                    new CultureInfo("sr-Latn"),
                    new CultureInfo("en")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "sr-Cyrl", uiCulture: "sr-Cyrl");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                //options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                //{
                //    // My custom request culture logic
                //    return new ProviderCultureResult("sr");
                //}));
            });

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
                options.HttpsPort = 443;
            });
        }

        /// <summary>
        /// Configures the application pipeline and pre-startup operations
        /// </summary>
        /// <param name="app">For configuring the application pipeline</param>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public void Configure(IApplicationBuilder app, GoldenTicketContext context, ILogger<Startup> logger, UserManager<Client> userManager)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
                app.UseHttpsRedirection();
            }
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Tickets}/{action=All}/{id?}");
            });
        }
    }
}
