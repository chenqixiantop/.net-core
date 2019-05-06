using EFCoreDemo2.Data;
using EFCoreDemo2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreDemo2.Migrations
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UserContext(
                serviceProvider.GetRequiredService<DbContextOptions<UserContext>>()))
            {
                // Look for any movies.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                new Users
                {
                    Id = 1,
                    UserName = "AJACK",
                    Password = "123456789"
                },

                new Users
                {
                    Id = 2,
                    UserName = "Bom",
                    Password = "123456789"
                });
                context.SaveChanges();
            }
        }
    }
}
