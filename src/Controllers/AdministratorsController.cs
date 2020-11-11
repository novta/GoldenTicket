using System;
using System.Threading.Tasks;
using GoldenTicket.Data;
using GoldenTicket.Models;
using GoldenTicket.Models.AdministratorsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GoldenTicket.Controllers
{
    /// <summary>
    /// Controller for technicians
    /// </summary>
    [Authorize(Roles = Role.Administrator)]
    public class AdministratorsController : Controller
    {
        private GoldenTicketContext _context;
        private UserManager<Client> _userManager;
        private ILogger _logger;

        /// <summary>
        /// intializes _context
        /// </summary>
        /// <param name="context">context of the technician</param>
        /// <param name="userManager">the usermanager</param>
        /// <param name="logger">the logger reference</param>
        public AdministratorsController(GoldenTicketContext context, UserManager<Client> userManager, ILogger<AdministratorsController> logger)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Gets all technicians
        /// </summary>
        /// <returns>A list of all technicians</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"All has failed with error '{ex.Message}'");
                throw;
            }
        }

        /// <summary>
        /// Gets the view for adding a technician
        /// </summary>
        /// <returns>The add technician view</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Adds a technician
        /// </summary>
        /// <returns>The technician list</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] NewClient newClient)
        {
            try
            {
                var client = new NewClient(newClient);
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                await _userManager.CreateAsync(client, newClient.Password);
                await _userManager.AddToRoleAsync(client, Role.Administrator);
                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Add has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }

        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Open(string id)
        {
            try
            {
                var client = await _context.Clients.FindAsync(id);
                return View(new Client(client));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Open has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }

        /// <summary>
        /// Opens the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Open([FromForm] Client client)
        {
            try
            {
                var oldClient = await _context.Clients.FindAsync(client.Id);
                if (oldClient.Role != client.Role)
                {
                    await _userManager.RemoveFromRoleAsync(oldClient, oldClient.Role);
                    await _userManager.AddToRoleAsync(client, client.Role);
                    await _userManager.UpdateAsync(client);
                }
                oldClient.FirstName = client.FirstName;
                oldClient.LastName = client.LastName;
                oldClient.Title = client.Title;
                oldClient.Chair = client.Chair;
                oldClient.Role = client.Role;
                _context.Clients.Update(oldClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Open has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }
    }
}