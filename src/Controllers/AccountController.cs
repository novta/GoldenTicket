using System;
using System.Threading.Tasks;
using GoldenTicket.EmailHelper;
using GoldenTicket.Extensions;
using GoldenTicket.Models;
using GoldenTicket.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace GoldenTicket.Controllers
{
    /// <summary>
    /// Controller for accounts
    /// </summary>
    public class AccountController : Controller
    {
        private readonly UserManager<Client> _userManager;
        private readonly SignInManager<Client> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes the Account Controller
        /// </summary>
        /// <param name="signInManager">manages sign in and out</param>
        /// <param name="userManager"></param>
        /// <param name="emailSender"></param>
        /// <param name="logger">logs</param>
        public AccountController(SignInManager<Client> signInManager, UserManager<Client> userManager, IEmailSender emailSender, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _logger = logger;
        }

        /// <summary>
        /// Handles logout
        /// </summary>
        /// <returns>login page</returns>
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            try
            {
                await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Login has failed with error '{ex.Message}'");
            }
            return View();
        }

        /// <summary>
        /// Logs the user out.
        /// </summary>
        /// <returns>Redirect to login</returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Logout has failed with error '{ex.Message}'");
            }
            return RedirectToAction(nameof(Login));
        }

        /// <summary>
        /// Method for logging in
        /// </summary>
        /// <param name="loginRequest">login information</param>
        /// <param name="returnUrl">URL to return to after login</param>
        /// <returns>login request page</returns>
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginRequest loginRequest, [FromQuery] string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(loginRequest);
            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(loginRequest.Username, loginRequest.Password, loginRequest.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation($"{User.Identity.Name} logged in.");
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(TicketsController.All), "Tickets");
                    }
                }
                else
                {
                    return View("AccessDenied");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Login has failed with error '{ex.Message}'");
            }
            return View(loginRequest);
        }

        /// <summary>
        /// Confirms the email.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns>Returns action result asynchronously.</returns>
        /// <exception cref="System.ApplicationException">Unable to load user with ID '{userId}</exception>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <returns>Returns action result.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        /// <summary>
        /// Forgets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns action result asynchronously.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToAction(nameof(ForgotPasswordConfirmation));
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Email, token, Request.Scheme);
                _logger.LogInformation($"ResetPasswordCallbackLink is created {callbackUrl}.");
                //await _emailSender.SendEmailAsync(model.Email, "Reset Password", $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>", "");
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        /// <summary>
        /// Forgets the password confirmation.
        /// </summary>
        /// <returns>Returns action result.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="userId">The reset password email.</param>
        /// <param name="code">The reset password token.</param>
        /// <returns>Returns action result.</returns>
        /// <exception cref="System.ApplicationException">A code must be supplied for password reset.</exception>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string userId, string code)
        {
            if (userId == null || code == null)
            {
                ModelState.AddModelError("", "Invalid password reset token");
            }
            var model = new ResetPasswordViewModel()
            {
                Email = userId,
                Token = code
            };
            return View(model);
        }
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Returns action result asynchronously.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(ResetPasswordConfirmation));
            }
            AddErrors(result);
            return View();
        }
        /// <summary>
        /// Resets the password confirmation.
        /// </summary>
        /// <returns>Returns action result.</returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        /// <summary>
        /// Denies access
        /// </summary>
        /// <returns>Access denied page</returns>
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}