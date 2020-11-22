using Microsoft.AspNetCore.Authorization;

namespace GoldenTicket.Extensions
{
    // https://stackoverflow.com/questions/24181888/authorize-attribute-with-multiple-roles    
    /// <summary>
    /// AuthorizeRoles Attribute extension
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Authorization.AuthorizeAttribute" />
    public sealed class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeRolesAttribute"/> class.
        /// </summary>
        /// <param name="roles">The roles.</param>
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}
