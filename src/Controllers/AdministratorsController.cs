using System;
using System.Threading.Tasks;
using GoldenTicket.Data;
using GoldenTicket.Models;
using GoldenTicket.Models.AdministratorsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        public AdministratorsController(GoldenTicketContext context, UserManager<Client> userManager, ILogger<AdministratorsController> logger)
        {
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
                var technicians = await _context.Users.ToListAsync();
                return View(technicians);
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
        public async Task<IActionResult> Add([FromForm] NewClient newTechnician)
        {
            try
            {
                var technician = new Client
                {
                    DateAdded = DateTime.Now,
                    UserName = $"{newTechnician.FirstName}.{newTechnician.LastName}",
                    FirstName = newTechnician.FirstName,
                    LastName = newTechnician.LastName,
                };
                await _userManager.CreateAsync(technician, newTechnician.Password);
                await _userManager.AddToRoleAsync(technician, Role.Administrator);
                return RedirectToAction(nameof(All));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Add has failed with error '{ex.Message}'");
            }
            return BadRequest();
        }
    }
}