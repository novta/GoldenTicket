namespace GoldenTicket.EmailHelpers
{
    /// <summary>
    /// EmailSettings class defines email settings for email sending 
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is development.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is development; otherwise, <c>false</c>.
        /// </value>
        public bool IsDevelopment { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [use SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use SSL]; otherwise, <c>false</c>.
        /// </value>
        public bool UseSsl { get; set; }
        /// <summary>
        /// Gets or sets the mail server.
        /// </summary>
        /// <value>
        /// The mail server.
        /// </value>
        public string MailServer { get; set; }
        /// <summary>
        /// Gets or sets the mail port.
        /// </summary>
        /// <value>
        /// The mail port.
        /// </value>
        public int MailPort { get; set; }
        /// <summary>
        /// Gets or sets the sender email.
        /// </summary>
        /// <value>
        /// The sender email.
        /// </value>
        public string SenderEmail { get; set; }
        /// <summary>
        /// Gets or sets the name of the sender.
        /// </summary>
        /// <value>
        /// The name of the sender.
        /// </value>
        public string SenderName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the admin email.
        /// </summary>
        /// <value>
        /// The admin email.
        /// </value>
        public string AdminEmail { get; set; }
    }
}
