using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityNS.Server.Core.DataAccess
{
    internal class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {
        }
    }
}