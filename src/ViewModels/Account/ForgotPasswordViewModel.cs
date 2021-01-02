namespace GoldenTicket.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="ForgotPasswordViewModel" />
    /// </summary>
    public class ForgotPasswordViewModel
    {
        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}