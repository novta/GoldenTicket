using System.Threading.Tasks;

namespace GoldenTicket.EmailHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmailHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="confirmationLink"></param>
        /// <returns></returns>
        Task SendConfirmationLinkEmailAsync(string email, string confirmationLink);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="resetLink"></param>
        /// <returns></returns>
        Task SendResetLinkEmailAsync(string email, string resetLink);
    }
}
