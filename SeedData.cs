using PROG7312_MunicipalServiceApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PROG7312_MunicipalServiceApp
{
    public static class SeedData
    {
        // This method will be called once when the application starts
        // to fill our data structures with sample events.
        public static void Initialize()
        {
            var events = new List<Event>
            {
                // Featured/High Priority Events
                new Event { Id = 1, Title = "City Council Budget Meeting", Description = "Public meeting to discuss the upcoming fiscal year budget.", Date = DateTime.Now.AddDays(7), Category = "Civic Duty", Location = "Cape Town City Hall", ImageUrl = "/images/city-hall.jpg", Priority = 1 },
                new Event { Id = 2, Title = "Emergency Water Supply Update", Description = "Urgent announcement regarding water supply interruptions in the Southern Suburbs.", Date = DateTime.Now.AddDays(2), Category = "Public Service Announcement", Location = "Online Stream", ImageUrl = "/images/water-pipes.jpg", Priority = 1 },

                // Regular Events
                new Event { Id = 3, Title = "Kirstenbosch Summer Concerts", Description = "Enjoy an evening of live music with local artists.", Date = DateTime.Now.AddDays(12), Category = "Music & Culture", Location = "Kirstenbosch Gardens", ImageUrl = "/images/concert.jpg", Priority = 5 },
                new Event { Id = 4, Title = "Sea Point Promenade Parkrun", Description = "Weekly 5km run along the beautiful Sea Point coast.", Date = DateTime.Now.AddDays(4), Category = "Health & Wellness", Location = "Sea Point Promenade", ImageUrl = "/images/parkrun.jpg", Priority = 5 },
                new Event { Id = 5, Title = "Greenmarket Square Flea Market", Description = "Explore unique crafts, clothing, and food from local vendors.", Date = DateTime.Now.AddDays(5), Category = "Community Market", Location = "Greenmarket Square", ImageUrl = "/images/market.jpg", Priority = 5 },
                new Event { Id = 6, Title = "First Thursdays Art Walk", Description = "Galleries and cultural attractions in the city centre stay open late.", Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1), Category = "Music & Culture", Location = "Cape Town CBD", ImageUrl = "/images/art-gallery.jpg", Priority = 3 },
                new Event { Id = 7, Title = "Newlands Ward 58 Community Meeting", Description = "Join your local councillor to discuss community safety.", Date = DateTime.Now.AddDays(20), Category = "Civic Duty", Location = "Newlands Community Hall", ImageUrl = "/images/community-meeting.jpg", Priority = 3 },
                new Event { Id = 8, Title = "Cape Town Marathon Training Run", Description = "Join a group training run in preparation for the upcoming marathon.", Date = DateTime.Now.AddDays(18), Category = "Health & Wellness", Location = "Green Point Park", ImageUrl = "/images/marathon.jpg", Priority = 5 },
                new Event { Id = 9, Title = "Oranjezicht City Farm Market Day", Description = "A farmer's market for independent local farmers and artisanal food producers.", Date = DateTime.Now.AddDays(11), Category = "Community Market", Location = "V&A Waterfront", ImageUrl = "/images/farm-market.jpg", Priority = 4 },
                new Event { Id = 10, Title = "Roadworks on M3 Highway", Description = "Scheduled maintenance will cause lane closures on the M3 near UCT.", Date = DateTime.Now.AddDays(30), Category = "Public Service Announcement", Location = "M3 Highway", ImageUrl = "/images/roadworks.jpg", Priority = 2 },
                new Event { Id = 11, Title = "Blouberg Beach Cleanup", Description = "Volunteer to help keep one of our most scenic beaches clean.", Date = DateTime.Now.AddDays(19), Category = "Civic Duty", Location = "Bloubergstrand", ImageUrl = "/images/beach-cleanup.jpg", Priority = 4 },
                new Event { Id = 12, Title = "Cape Town Jazz Festival", Description = "Africa's grandest gathering celebrating the art of jazz.", Date = DateTime.Now.AddDays(45), Category = "Music & Culture", Location = "CTICC", ImageUrl = "/images/jazz-festival.png", Priority = 2 },
                new Event { Id = 13, Title = "Library Reading Hour for Kids", Description = "A fun and interactive reading session for children aged 5-8.", Date = DateTime.Now.AddDays(10), Category = "Community", Location = "Sea Point Library", ImageUrl = "/images/library.jpg", Priority = 5 },
                new Event { Id = 14, Title = "Free Yoga in the Park", Description = "A free weekly yoga session open to all fitness levels.", Date = DateTime.Now.AddDays(11), Category = "Health & Wellness", Location = "De Waal Park", ImageUrl = "/images/yoga.jpg", Priority = 5 },
                new Event { Id = 15, Title = "Load Shedding Schedule Update", Description = "Please be advised of the updated load shedding schedule for the week.", Date = DateTime.Now.AddDays(1), Category = "Public Service Announcement", Location = "City-Wide", ImageUrl = "/images/load-shedding.jpg", Priority = 2 },
                new Event { Id = 16, Title = "Woodstock Street Art Tour", Description = "A guided tour of the vibrant street art and murals in Woodstock.", Date = DateTime.Now.AddDays(25), Category = "Music & Culture", Location = "Woodstock", ImageUrl = "/images/street-art.jpg", Priority = 4 }
            };

            foreach (var ev in events)
            {
                // For the Sorted Dictionary, we need a unique key.
                var uniqueKey = ev.Date.AddTicks(ev.Id);
                GlobalData.EventsByDate.Add(uniqueKey, ev);
                GlobalData.UniqueEventCategories.Add(ev.Category);
                GlobalData.FeaturedEvents.Enqueue(ev);
            }
        }
    }
}