﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithAssignment.Data;
using ZenithAssignment.Models;

namespace ZenithAssignment.Migrations
{
    public class seedData
    {

        public static void Initialize(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            getUsers(context, roleManager, userManager);
      

        }


        private static async void getUsers(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("Member"))
                await roleManager.CreateAsync(new IdentityRole("Member"));


            string[] emails = { "a@a.a", "m@m.m" };
            string[] userNames = { "a", "m" };

            if (await userManager.FindByEmailAsync(emails[0]) == null)
            {
                var user = new ApplicationUser
                {

                    Email = emails[0],

                    UserName = userNames[0],

                    FirstName = userNames[0],

                    LastName = userNames[0],

                    
                };
                var password = new PasswordHasher<ApplicationUser>().HashPassword(user, "P@$$w0rd");
                user.PasswordHash = password;
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    await userManager.AddToRoleAsync(user, "Member");
                }
            }
            if (await userManager.FindByEmailAsync(emails[1]) == null)

            {

                var user = new ApplicationUser

                {

                    Email = emails[1],

                    UserName = userNames[1],

                    FirstName = userNames[1],

                    LastName = userNames[1],

                };

                var password = new PasswordHasher<ApplicationUser>().HashPassword(user, "P@$$w0rd");
                user.PasswordHash = password;
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Member");
                }
            }

            getActivities(context);

            context.SaveChanges();

            getEvents(context);

            context.SaveChanges();
        }


        private static void getActivities(ApplicationDbContext db)
        {

            string Text = "18/10/2016";
            DateTime myDate1 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "19/10/2016";
            DateTime myDate2 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "20/10/2016";
            DateTime myDate3 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);


            if (!db.Activities.Any())
            {

                db.Activities.Add(new Activity
                {
                    ActivityDec = "Senior’s Golf Tournament",
                    DateCreated = myDate1
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Leadership General Assembly Meeting",
                    DateCreated = myDate2
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Youth Bowling Tournament",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Young ladies cooking lessons",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Youth craft lessons",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Youth choir practice",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Lunch",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Pancake Breakfast",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Swimming Lessons for the youth",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Swimming Exercise for parents",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Bingo Tournament",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "BBQ Lunch",
                    DateCreated = myDate3
                });
                db.Activities.Add(new Activity
                {
                    ActivityDec = "Garage Sale",
                    DateCreated = myDate3
                });
            }
    
        }

        private static void getEvents(ApplicationDbContext db)
        {

            TimeSpan FTime = new TimeSpan(08, 30, 0);
            TimeSpan TTime = new TimeSpan(10, 30, 0);

            string Text = "09/27/2016";
            DateTime myDate1 = DateTime.ParseExact(Text, "MM/dd/yyyy", null);

            Text = "09/28/2016";
            DateTime myDate2 = DateTime.ParseExact(Text, "MM/dd/yyyy", null);

            Text = "09/29/2016";
            DateTime myDate3 = DateTime.ParseExact(Text, "MM/dd/yyyy", null);
            //Convert.ToDateTime("2016/09/10");

            if (!db.Events.Any())
            {                
                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/18/2016 08:30", "MM/dd/yyyy HH:mm", null),                
                    ToDate = DateTime.ParseExact("11/18/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/19/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/19/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,

                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/21/2016 17:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/21/2016 19:15", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/21/2016 19:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/21/2016 20:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Young ladies cooking lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/22/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/22/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth craft lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/22/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/22/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth choir practice")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/22/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/22/2016 13:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/23/2016 07:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Pancake Breakfast")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Lessons for the youth")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Exercise for parents")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/23/2016 12:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Bingo Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/23/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/23/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "BBQ Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/23/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/23/2016 18:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Garage Sale")
                });

                //Next week

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/25/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/25/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/26/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/26/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/28/2016 17:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/28/2016 19:15", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/28/2016 19:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/28/2016 20:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Young ladies cooking lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/29/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/29/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth craft lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/29/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/29/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth choir practice")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/29/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/29/2016 13:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/30/2016 07:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Pancake Breakfast")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Lessons for the youth")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Exercise for parents")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/30/2016 12:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Bingo Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/30/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/30/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "BBQ Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("11/30/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("11/30/2016 18:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Garage Sale")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/01/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/01/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Exercise for parents")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/01/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/01/2016 12:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Bingo Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/01/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/01/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "BBQ Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/01/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/01/2016 18:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Garage Sale")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/02/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/02/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/02/2016 17:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/02/2016 19:15", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/02/2016 19:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/03/2016 20:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Young ladies cooking lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/03/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/03/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth craft lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/03/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/03/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth choir practice")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("12/03/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("12/03/2016 13:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Lunch")
                });

            }
        }


    }
}
