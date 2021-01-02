using GoldenTicket.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GoldenTicket.Extensions
{
    /// <summary>
    /// UrlHelperExtensions extends IUrlHelper to support creation of confirmation link and reset password link.
    /// </summary>
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Emails the confirmation link.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <param name="scheme">The scheme.</param>
        /// <returns>Generates an URL with an absolute path for an action method, which contains the specified action name, controller name, route values, and protocol to use.</returns>
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
        /// <summary>
        /// Resets the password callback link.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <param name="scheme">The scheme.</param>
        /// <returns>Generates an URL with an absolute path for an action method, which contains the specified action name, controller name, route values, and protocol to use.</returns>
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: nameof(AccountController.ResetPassword),
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
