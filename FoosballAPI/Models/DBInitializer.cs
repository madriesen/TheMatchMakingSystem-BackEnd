using FoosballAPI.Data;
using FoosballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoosballAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user.
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            context.Roles.AddRange(
              new Role { Name = "User" },
              new Role { Name = "Admin" });
            context.SaveChanges();

            context.Users.AddRange(
                new User {FirstName = "user", LastName = "Test", Email = "user.user@thomasmore.be", Password = "user", Address = "Doelenstraat 46", Dob = new DateTime(1989, 11, 19), RoleID = 1, Town = "Geel", ZipCode="2360"},
                new User {FirstName = "admin", LastName = "Test", Email = "admin.admin@thomasmore.be", Password = "admin", Address = "Doelenstraat 46", Dob = new DateTime(1989, 11, 19), RoleID = 2, Town = "Geel", });
            context.SaveChanges();
        }
    }
}
