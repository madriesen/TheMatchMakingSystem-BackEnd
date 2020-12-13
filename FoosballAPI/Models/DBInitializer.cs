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
            context.Ploegen.AddRange(
                new Ploeg { Name = "Ploeg 1", CompanyName = "Strobbo", Address = "Doelenstraat 46", Town = "Geel", ZipCode = "2360" },
                new Ploeg { Name = "Ploeg 2", CompanyName = "Alectra", Address = "Hardloopstraat 49", Town = "Rood", ZipCode = "4756"}
               );
            context.SaveChanges();
            

            context.Users.AddRange(

                new User { Password = BCrypt.Net.BCrypt.HashPassword("user"), FirstName = "user", LastName = "Test", Email = "user.user@thomasmore.be", Address = "Doelenstraat 46", Dob = new DateTime(1989, 11, 19), RoleID = 1, Town = "Geel", ZipCode = "2360", PloegID = 2, Ranking = 14 },
                new User { Password = BCrypt.Net.BCrypt.HashPassword("admin"), FirstName = "admin", LastName = "Test", Email = "admin.admin@thomasmore.be", Address = "Doelenstraat 46", Dob = new DateTime(1989, 11, 19), RoleID = 2, Town = "Geel", ZipCode = "2360", PloegID = 1, Ranking = 2 },
                new User { Password = BCrypt.Net.BCrypt.HashPassword("test"), FirstName = "Gust", LastName = "van der Sanden", Email = "gustvdsanden@gmail.com", Address = "Wijerken 41", Dob = new DateTime(1999, 08, 28), RoleID = 1, Town = "Lommel", ZipCode = "3920", PloegID=2, Ranking = 53 },
                new User { Password = BCrypt.Net.BCrypt.HashPassword("test"), FirstName = "test", LastName = "user1", Email = "testuser1@gmail.com", Address = "Wijerken 41", Dob = new DateTime(1999, 08, 28), RoleID = 1, Town = "Lommel", ZipCode = "3920", PloegID = 2, Ranking = 6 },
                new User { Password = BCrypt.Net.BCrypt.HashPassword("test"), FirstName = "test", LastName = "user2", Email = "testuser2@gmail.com", Address = "Wijerken 41", Dob = new DateTime(1999, 08, 28), RoleID = 1, Town = "Lommel", ZipCode = "3920", PloegID = 2, Ranking = 4 },
                new User { Password = BCrypt.Net.BCrypt.HashPassword("test"), FirstName = "test", LastName = "user3", Email = "testuser3@gmail.com", Address = "Wijerken 41", Dob = new DateTime(1999, 08, 28), RoleID = 1, Town = "Lommel", ZipCode = "3920", PloegID = 1 ,Ranking = 11},
                new User { Password = BCrypt.Net.BCrypt.HashPassword("test"), FirstName = "Jorn", LastName = "Snoeks", Email = "jornsnoeks@gmail.com", Address = "Rechtsafendoor 46", Dob = new DateTime(1991, 6, 14), RoleID = 1, Town = "Lommel", ZipCode = "3920" , PloegID = 1,Ranking=10 }
                );
            context.SaveChanges();
            
            context.Teams.AddRange(
                new Team { PloegID= 1, Player1ID = 7, Player2ID = 6},
                new Team { PloegID = 2, Player1ID = 3, Player2ID = 4 },
                new Team { PloegID = 2, Player1ID = 3, Player2ID = 5 }

             );
            context.SaveChanges();
            context.WedstrijdTypes.AddRange(
                new WedstrijdType { Name = "1v1" },
                new WedstrijdType { Name = "2v2" }
                );
            context.SaveChanges();
            context.Tables.AddRange(
                new Table { Name = "tafel 1",PloegID=1 , UserID=7},
                new Table { Name = "tafel 2", PloegID = 1, UserID = 7 },
                new Table { Name = "tafel 3", PloegID = 1, UserID = 7 },
                new Table { Name = "tafel 1", PloegID = 2, UserID = 3 },
                new Table { Name = "tafel 2", PloegID = 2, UserID = 3 },
                new Table { Name = "tafel 3", PloegID = 2, UserID = 3 }

              );
            context.SaveChanges();
         
            context.Tournooien.AddRange(
                new Tournooi { Name="2019-2020",Ploeg1ID= 1, Ploeg2ID=2},
                new Tournooi { Name = "2020-2021", Ploeg1ID = 1, Ploeg2ID = 2 }

                );
            context.SaveChanges();
            
            context.Wedstrijden.AddRange(
                new Wedstrijd {Date=new DateTime(2019,06,12), RondeNummer=1, WedstrijdTypeID=2, TournooiID=1,TableID=1,Team1ID=1,Team2ID=2 },
                new Wedstrijd { Date = new DateTime(2019, 06, 13), RondeNummer = 1, WedstrijdTypeID = 2, TournooiID = 1, TableID = 1, Team1ID = 1, Team2ID = 3 },
                new Wedstrijd { Date = new DateTime(2019, 06, 14), RondeNummer = 2, WedstrijdTypeID = 2, TournooiID = 1, TableID = 2, Team1ID = 2, Team2ID = 3 }
                );
            context.SaveChanges();

        }
    }
}
