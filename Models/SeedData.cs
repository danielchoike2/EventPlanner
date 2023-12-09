using Microsoft.EntityFrameworkCore;
using EventPlanner.Data;

namespace EventPlanner.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EventPlannerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EventPlannerContext>>()))
            {
                if (context == null || context.OfferedService == null)
                {
                    throw new ArgumentNullException("Null EventPlannerContext");
                }

                // Look for any movies.
                if (context.OfferedService.Any())
                {
                    return;   // DB has been seeded
                }

                context.OfferedService.AddRange(
                new OfferedService
                {

                    Name = "DJ",
                    Description = "Music services",
                    Rate = 30
                },

                    new OfferedService
                    {

                        Name = "Photography",
                        Description = "Professional photos taken and edited. Delivered via digital files ",
                        Rate = 50
                    },

                    new OfferedService
                    {

                        Name = "Videography",
                        Description = "Professional video taken and edited. Delivered via digital file.",
                        Rate = 70
                    },
                    new OfferedService
                    {

                        Name = "Guest Speaker",
                        Description = "Professional speaker to speak at your event.",
                        Rate = 50
                    },
                    new OfferedService
                    {

                        Name = "String Quartet",
                        Description = "String quartet to play at your event.",
                        Rate = 60
                    },

                    new OfferedService
                    {

                        Name = "Mariachi Band",
                        Description = "Mariachi Band to play at your event.",
                        Rate = 60
                    },

                    new OfferedService
                    {

                        Name = "Wedding Officiant",
                        Description = "Professional certified officiant for your wedding.",
                        Rate = 50
                    }
                );
                context.Schedule.AddRange(
                   new Schedule
                   {

                       ScheduleDate = DateTime.Parse("2024-2-12"),
                       Location = "Blue Bridge Event Center",
                       ServiceName = "DJ",
                       Rate = 30,
                       Start = "2:00PM",
                       End = "6:00PM"
                   },

                   new Schedule
                   {

                       ScheduleDate = DateTime.Parse("2024-2-13"),
                       Location = "Cobblestone Farm",
                       ServiceName = "Photography",
                       Rate = 50,
                       Start = "1:00PM",
                       End = "3:00PM"
                   },

                   new Schedule
                   {

                       ScheduleDate = DateTime.Parse("2024-2-14"),
                       Location = "Peninsula Room",
                       ServiceName = "Videography",
                       Rate = 70,
                       Start = "2:00PM",
                       End = "4:00PM"
                   },
                   new Schedule
                   {

                       ScheduleDate = DateTime.Parse("2024-2-15"),
                       Location = "Kirkbride Hall",
                       ServiceName = "Mariachi Band",
                       Rate = 60,
                       Start = "5:00PM",
                       End = "7:00PM"
                   },
                   new Schedule
                   {

                       ScheduleDate = DateTime.Parse("2024-2-16"),
                       Location = "Cobblestone Farm",
                       ServiceName = "Wedding Officiant",
                       Rate = 50,
                       Start = "3:00PM",
                       End = "5:00PM"
                   }
               );



                context.SaveChanges();
            }
        }
    }
}