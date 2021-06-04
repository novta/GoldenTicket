// Copyright © 2020 Ken Haggerty (https://kenhaggerty.com)
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace GoldenTicket.EmailHelpers
{
    /// <summary>
    /// Interface for the EmailSender service to send emails.
    /// </summary>
    /// <remarks>
    /// https://kenhaggerty.com/articles/article/aspnet-core-22-smtp-emailsender-implementation
    /// https://kenhaggerty.com/articles/article/aspnet-core-31-smtp-emailsender
    /// </remarks>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email to the <paramref name="email" /> address with <paramref name="subject" />,
        /// <paramref name="textMessage" /> and <paramref name="htmlMessage" />.
        /// </summary>
        /// <param name="email">The send to email address.</param>
        /// <param name="subject">The email's subject.</param>
        /// <param name="textMessage">The email's MimeKit.BodyBuilder.TextBody.</param>
        /// <param name="htmlMessage">The email's MimeKit.BodyBuilder.HtmlBody.</param>
        Task SendEmailAsync(string email, string subject, string textMessage, string htmlMessage);

        /// <summary>
        /// Sends an email to the address set with the readonly <see cref="EmailSettings.AdminEmail" /> property
        /// with <paramref name="subject" /> and <paramref name="textMessage" /> including HttpContext properties.
        /// </summary>
        /// <param name="subject">The email's subject.</param>
        /// <param name="textMessage">The email's MimeMessage.Body.TextPart.</param>
        Task SendAdminEmailAsync(string subject, string textMessage);
    }
}