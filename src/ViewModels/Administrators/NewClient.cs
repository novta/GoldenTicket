using GoldenTicket.Models;

namespace GoldenTicket.ViewModels.Administrators
{
    /// <summary>
    /// For adding a new technician
    /// </summary>
    public class NewClient : Client
    {
        /// <summary>
        /// The password of the technician
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewClient"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public NewClient(Client client) : base(client)
        {
        }
    }
}