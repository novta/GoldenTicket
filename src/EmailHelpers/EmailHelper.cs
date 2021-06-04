using System.Threading.Tasks;

namespace GoldenTicket.EmailHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailHelper : IEmailHelper
    {
        private readonly IEmailSender _emailSender;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailSender"></param>
        public EmailHelper(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="confirmationLink"></param>
        /// <returns></returns>
        public Task SendConfirmationLinkEmailAsync(string email, string confirmationLink)
        {
            return _emailSender.SendEmailAsync(email, "Confirm your email",
                $"Hello there,\n\nTo confirm your email click {confirmationLink}",
                $"<h3>Hello there,</h3><br> To confirm your email click <a href=\"{confirmationLink}\">Confirmation link</a>");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="resetLink"></param>
        /// <returns></returns>
        public Task SendResetLinkEmailAsync(string email, string resetLink)
        {
            return _emailSender.SendEmailAsync(email, "Reset your password",
                $"Hello there,\n\nTo reset your password click {resetLink}",
                $"<h3>Hello there,</h3><br> To reset your password click <a href=\"{resetLink}\">Reset link</a>");
        }
    }
}
