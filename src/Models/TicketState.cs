namespace GoldenTicket.Models
{
    /// <summary>
    /// TicketState represent ticket state
    /// </summary>
    public enum TicketState
    {
        /// <summary>
        /// The draft
        /// </summary>
        Draft,
        /// <summary>
        /// The commited
        /// </summary>
        Commited,
        /// <summary>
        /// The wait for chair approval
        /// </summary>
        WaitForChairApproval,
        /// <summary>
        /// The wait for scientific teaching council
        /// </summary>
        WaitForScientificTeachingCouncil,
        /// <summary>
        /// The approved
        /// </summary>
        Approved,
        /// <summary>
        /// The rejected
        /// </summary>
        Rejected,
    }
}
