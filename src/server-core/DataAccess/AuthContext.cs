using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using IdentityNS.Server.Core.Common;
using Microsoft.AspNet.Identity;
using System.Text;

namespace IdentityNS.Server.Core.DataAccess
{
    internal class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {
            Database.SetInitializer(new AuthDbInitializer());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }

    internal class AuthDbInitializer : DropCreateDatabaseIfModelChanges<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            if (context.Clients.Count() > 0)
            {
                return;
            }

            CreateDefaultAdminUser(context);

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();
        }

        private void CreateDefaultAdminUser(AuthContext context)
        {
            using (var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context)))
            {
                var user = new IdentityUser { UserName = "root" };

                var result = userManager.Create(user, "p@ssw0rd");
                if (!result.Succeeded)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("Create default \"administrator\" user failed, error: ");
                    foreach (string err in result.Errors)
                    {
                        builder.AppendLine(err);
                    }

                    throw new Exception(builder.ToString());
                }
            }
        }

        private static List<Client> BuildClientsList()
        {

            List<Client> clientsList = new List<Client>
            {
                new Client
                {
                    Id = "identity-server-frontend",
                    Secret= Helper.GetHash("p@ssw0rd"),
                    Name="Identity Server Front-End",
                    ApplicationType =  ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "*" //"http://ngauthenticationweb.azurewebsites.net"
                },
                new Client
                {
                    Id = "employeemanage",
                    Secret= Helper.GetHash("abc@123"),
                    Name="Employee Management Web Application",
                    ApplicationType =  ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "*" //"http://ngauthenticationweb.azurewebsites.net"
                },
                new Client
                {
                    Id = "productmanage",
                    Secret = Helper.GetHash("123@abc"),
                    Name="Product Management Console Application",
                    ApplicationType =ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                }
            };

            return clientsList;
        }
    }
}