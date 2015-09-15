namespace ITSFCRegistration.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ITSFCRegistration.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
        }

         

        protected override void Seed(ITSFCRegistration.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                roleManager.Create(role);

                var studentRole = new IdentityRole
                {
                    Name = "Student"
                };
                roleManager.Create(studentRole);
            }
            context.SaveChanges();


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");

            context.Users.AddOrUpdate(u => u.StudentID,
            new ApplicationUser[]
            {
                    new ApplicationUser
                    {
                        StudentID = "S00000000",
                        UserName = "S00000000",
                        FirstName = "Joe",
                        SecondName = "Bloggs",
                        Email = "S00000000@mail.itsligo.ie",
                        CurrentClub = "Sligo Rovers",
                        PreferredPosition = "Striker",
                        Mobile = "0861873827",
                        DOB = new DateTime(91,10,10),
                        PasswordHash = passwordHash.HashPassword("S00000000")
                        
                                            },
                    new ApplicationUser
                    {
                        StudentID = "S00000001",
                        UserName = "S00000001",
                        FirstName = "Fred",
                        SecondName = "Foops",
                        Email = "S00000001@mail.itsligo.ie",
                        CurrentClub = "Bray Wanders",
                        PreferredPosition = "Goal Keeper",
                        DOB = new DateTime(96,08,10),
                        Mobile = "0861873827",
                        PasswordHash = passwordHash.HashPassword("S00000001")
                                            },
                  new ApplicationUser
                {
                    StudentID = "ppowell",
                    UserName = "ppowell",
                    FirstName = "Paul",
                    SecondName = "Powell",
                    Email = "powell.paul@itsligo.ie",
                    CurrentClub = "IT Sligo",
                    PreferredPosition = "Secretary",
                    DOB = new DateTime(74,10,26),
                    Mobile = "0861238381",
                    PasswordHash = passwordHash.HashPassword("ppowell$1")
                },
            }


             );
            // Assign Roles

            context.SaveChanges();
            var admin = userManager.FindByName("ppowell");
            userManager.AddToRole(admin.Id, "Administrator");
            var s1 = userManager.FindByName("S00000000");
            userManager.AddToRole(s1.Id, "Student");
            var s2 = userManager.FindByName("S00000001");
            userManager.AddToRole(s2.Id, "Student");
            context.SaveChanges();
        }
    }
}
