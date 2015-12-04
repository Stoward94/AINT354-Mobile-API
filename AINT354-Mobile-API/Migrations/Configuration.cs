using AINT354_Mobile_API.Models;

namespace AINT354_Mobile_API.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            context.Colours.AddOrUpdate(p => p.ColourName,
                new Colour { ColourName = "Red" },
                new Colour { ColourName = "Green" },
                new Colour { ColourName = "Blue" },
                new Colour { ColourName = "Orange" }
            );
            context.SaveChanges();

            context.Users.AddOrUpdate(p => p.Email,
                new User { Id = 1, Name = "Luke Stoward", Email = "luke@email.com"}
            );
            context.SaveChanges();

            Guid calendarId = Guid.NewGuid();

            context.Calendars.AddOrUpdate(p => p.Name,
                new Calendar { Id = calendarId, Name = "Home", ColourId = 1, Description = "My calendar for home", OwnerId = 1 }
              
            );

            //Add sample events
            context.Events.AddOrUpdate(p => p.StartDateTime,
                new Event
                {
                    Id = Guid.NewGuid(), CalendarId = calendarId, CreatorId = 1, CreatedDate = DateTime.Now, Title = "My First Event", Body = "This is the body text", Location = "My House",
                    AllDay = false, StartDateTime = DateTime.Now.AddDays(1), EndDateTime = DateTime.Now.AddDays(1).AddHours(2)
                },

                new Event
                {
                    Id = Guid.NewGuid(), CalendarId = calendarId, CreatorId = 1, CreatedDate = DateTime.Now.AddHours(1), Title = "My Second Event", Body = "This is the body text", Location = "Uni",
                    AllDay = false, StartDateTime = DateTime.Now.AddHours(2), EndDateTime = DateTime.Now.AddHours(2).AddMinutes(30)
                },

                new Event
                {
                    Id = Guid.NewGuid(), CalendarId = calendarId, CreatorId = 1, CreatedDate = DateTime.Now.AddDays(2), Title = "My Third Event", Body = "This is the body text", Location = "4 Allendale Road",
                    AllDay = false, StartDateTime = DateTime.Now.AddDays(3), EndDateTime = DateTime.Now.AddDays(3).AddHours(4)
                }

            );
        }
    }
}
