using System;

namespace GoldenTicket.Models.AdministratorsViewModels
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
    }
}