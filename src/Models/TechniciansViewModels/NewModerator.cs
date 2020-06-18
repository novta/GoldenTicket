using System;

namespace GoldenTicket.Models.ModeratorsViewModels
{
    /// <summary>
    /// For adding a new technician
    /// </summary>
    public class NewModerator : Moderator
    {
        /// <summary>
        /// The password of the technician
        /// </summary>
        public string Password { get; set; }
    }
}