using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using IdentityNS.Server.Core.Common;

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

            context.Clients.AddRange(BuildClientsList());
            context.SaveChanges();
        }

        private static List<Client> BuildClientsList()
        {

            List<Client> ClientsList = new List<Client>
            {
                new Client
                { Id = "employeemanage",
                    Secret= Helper.GetHash("abc@123"),
                    Name="Employee Management Web Application",
                    ApplicationType =  ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "*" //"http://ngauthenticationweb.azurewebsites.net"
                },
                new Client
                { Id = "productmanage",
                    Secret = Helper.GetHash("123@abc"),
                    Name="Product Management Console Application",
                    ApplicationType =ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                }
            };

            return ClientsList;
        }
    }
}