using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithAssignment.Data;

namespace ZenithAssignment.Models
{
    public class seedData
    {


        public static void Initialize(ApplicationDbContext context, IServiceProvider provider)
        {
            getUsers(context, provider);
      

        }


        private static async void getUsers(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await roleManager.RoleExistsAsync("Member"))
                await roleManager.CreateAsync(new IdentityRole("Member"));
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] emails = { "a@a.a", "m@m.m" };
            string[] userNames = { "a", "m" };

            if (userManager.FindByEmailAsync(emails[0]) == null)
            {
                var user = new ApplicationUser
                {

                    Email = emails[0],

                    UserName = userNames[0],

                    FirstName = userNames[0],

                    LastName = userNames[0],

                };

                var result = userManager.CreateAsync(user);



                var password = new PasswordHasher<ApplicationUser>();

                password.HashPassword(user, "P@$$w0rd");

            }
            if (userManager.FindByEmailAsync(emails[1]) == null)

            {

                var user = new ApplicationUser

                {

                    Email = emails[1],

                    UserName = userNames[1],

                    FirstName = userNames[1],

                    LastName = userNames[1],

                };

                var result = userManager.CreateAsync(user);

                var password = new PasswordHasher<ApplicationUser>();

                password.HashPassword(user, "P@$$w0rd");

            }

            //context.context.Activities.Add(t => t.ActivityId, getActivities().ToArray());

            getActivities(context);
       
     
           

            //context.Add(t => t.ActivityId, getActivities(context).ToArray());

            context.SaveChanges();



            //context.db.Events.Add(p => p.EventId, getEvents(context).ToArray());

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
                    FromDate = DateTime.ParseExact("10/18/2016 08:30", "MM/dd/yyyy HH:mm", null),                
                    ToDate = DateTime.ParseExact("10/18/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/19/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/19/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,

                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/21/2016 17:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/21/2016 19:15", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/21/2016 19:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/21/2016 20:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Young ladies cooking lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/22/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/22/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth craft lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/22/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/22/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth choir practice")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/22/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/22/2016 13:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/23/2016 07:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Pancake Breakfast")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Lessons for the youth")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Exercise for parents")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/23/2016 12:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Bingo Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/23/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/23/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "BBQ Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/23/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/23/2016 18:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Garage Sale")
                });

                //Next week

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/25/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/25/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate1,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/26/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/26/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate2,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/28/2016 17:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/28/2016 19:15", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/28/2016 19:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/28/2016 20:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Young ladies cooking lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/29/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/29/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth craft lessons")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/29/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/29/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Youth choir practice")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/29/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/29/2016 13:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/30/2016 07:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Pancake Breakfast")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Lessons for the youth")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Swimming Exercise for parents")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/30/2016 12:30", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Bingo Tournament")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/30/2016 12:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/30/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "BBQ Lunch")
                });

                db.Events.Add(new Event
                {
                    FromDate = DateTime.ParseExact("10/30/2016 13:00", "MM/dd/yyyy HH:mm", null),
                    ToDate = DateTime.ParseExact("10/30/2016 18:00", "MM/dd/yyyy HH:mm", null),
                    DateCreated = myDate3,
                    ApplicationUser = db.Users.First(a => a.UserName == "a"),
                    Activity = db.Activities.First(t => t.ActivityDec == "Garage Sale")
                });
            }
        }


    }
}
