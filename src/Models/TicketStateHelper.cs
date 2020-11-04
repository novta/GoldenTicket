using GoldenTicket.Data;
using GoldenTicket.Models;
using GoldenTicket.Models.TicketsViewModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace GoldenTicket.Helpers
{
    /// <summary>
    /// TicketStateHelper is handler class to extract data from TicketDetails
    /// </summary>
    public static class TicketStateHelper
    {
        /// <summary>
        /// Users the can review.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="ticketDetails">The ticket details.</param>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public static bool UserCanReview(ClaimsPrincipal user, TicketDetails ticketDetails, out string role)
        {
            var state = ticketDetails.Ticket.State;
            if (!ticketDetails.Ticket.Open)
            {
                role = "";
                return false;
            }
            var chair = user.Claims.FirstOrDefault(x => x.Type == CustomClaims.Chair)?.Value;
            if (user.IsInRole(Role.FinanceOfficer) && state == TicketState.Commited)
            {
                role = Role.FinanceOfficer;
                return true;
            }
            else if (user.IsInRole(Role.SecretaryOfChair) && state == TicketState.WaitForChairApproval && chair == ticketDetails.Client.Chair)
            {
                role = Role.SecretaryOfChair;
                return true;
            }
            else if (user.IsInRole(Role.SecretaryOfScientificTeachingCouncil) && state == TicketState.WaitForScientificTeachingCouncil)
            {
                role = Role.SecretaryOfScientificTeachingCouncil;
                return true;
            }
            else if (user.IsInRole(Role.HeadAccountant))
            {
                role = Role.HeadAccountant;
                return true;
            }
            else if (user.IsInRole(Role.ViceDeanForFinance))
            {
                role = Role.ViceDeanForFinance;
                return true;
            }
            role = "";
            return false;
        }

        /// <summary>
        /// Users the can review.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="ticketDetails">The ticket details.</param>
        /// <returns></returns>
        //public static bool UserCanWithdraw(ClaimsPrincipal user, TicketDetails ticketDetails)
        //{
        //    var result = false;
        //    return result;
        //}
    }
}
