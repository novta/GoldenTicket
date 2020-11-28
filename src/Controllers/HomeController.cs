using GoldenTicket.Data;
using GoldenTicket.Models;
using GoldenTicket.Models.HomeViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GoldenTicket.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<Client> _userManager;
        private GoldenTicketContext _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="context">The context.</param>
        /// <param name="logger"></param>
        public HomeController(UserManager<Client> userManager, GoldenTicketContext context, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var umClient = await _userManager.GetUserAsync(User);
                var client = await _context.Clients.FindAsync(umClient.Id);
                var updateClient = new ClientUpdate(client);
                return View(updateClient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Open has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(ClientUpdate updatedClient)
        {
            try
            {
                var client = await _userManager.GetUserAsync(User);
                client.FirstName = updatedClient.FirstName;
                client.LastName = updatedClient.LastName;
                client.Title = updatedClient.Title;
                client.Email = updatedClient.Email;
                client.PhoneNumber = updatedClient.PhoneNumber;
                await _userManager.UpdateAsync(client);
                _context.Clients.Update(client);
                await _context.SaveChangesAsync();
                if (!string.IsNullOrWhiteSpace(updatedClient.CurrentPassword) &&
                    !string.IsNullOrWhiteSpace(updatedClient.NewPassword) &&
                    updatedClient.CurrentPassword != updatedClient.NewPassword)
                {
                    updatedClient.Status = await _userManager.ChangePasswordAsync(client, updatedClient.CurrentPassword, updatedClient.NewPassword);
                }
                else if (!string.IsNullOrWhiteSpace(updatedClient.CurrentPassword) &&
                    !string.IsNullOrWhiteSpace(updatedClient.NewPassword) &&
                    updatedClient.CurrentPassword == updatedClient.NewPassword)
                {
                    updatedClient.Status = IdentityResult.Failed(new IdentityError()
                    { 
                        Code = "PasswordNotChanged",
                        Description = "New password have to be changed!"
                    });
                }
                return View(updatedClient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Open has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }
    }
}
