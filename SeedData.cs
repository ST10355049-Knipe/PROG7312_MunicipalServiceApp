using PROG7312_MunicipalServiceApp.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace PROG7312_MunicipalServiceApp
{
    public static class SeedData
    {
        public static void Initialize()
        {
            // We'll call both seeding methods when the app starts.
            SeedEvents();
            SeedServiceRequests();
        }

        // This method contains all the Event data from Part 2.
        private static void SeedEvents()
        {
            // This check prevents adding duplicate data every time the app restarts.
            if (GlobalData.EventsByDate.Count() > 0) return;

            var events = new List<Event>
            {
                // Set the priority for the requested featured events to 1 or 2.
                new Event { Id = 2, Title = "Emergency Water Supply Update", Description = "Urgent announcement regarding water supply interruptions in the Southern Suburbs.", Date = DateTime.Now.AddDays(2), Category = "Public Service Announcement", Location = "Online Stream", ImageUrl = "/images/water-pipes.jpg", Priority = 1 },
                new Event { Id = 15, Title = "Load Shedding Schedule Update", Description = "Please be advised of the updated load shedding schedule for the week.", Date = DateTime.Now.AddDays(1), Category = "Public Service Announcement", Location = "City-Wide", ImageUrl = "/images/load-shedding.jpg", Priority = 1 },
                new Event { Id = 8, Title = "Cape Town Marathon Training Run", Description = "Join a group training run in preparation for the upcoming marathon.", Date = DateTime.Now.AddDays(18), Category = "Health & Wellness", Location = "Green Point Park", ImageUrl = "/images/marathon.jpg", Priority = 2 },
                new Event { Id = 16, Title = "Woodstock Street Art Tour", Description = "A guided tour of the vibrant street art and murals in Woodstock.", Date = DateTime.Now.AddDays(25), Category = "Music & Culture", Location = "Woodstock", ImageUrl = "/images/street-art.jpg", Priority = 2 },

                // Other events with lower priority
                new Event { Id = 1, Title = "City Council Budget Meeting", Description = "Public meeting to discuss the upcoming fiscal year budget.", Date = DateTime.Now.AddDays(7), Category = "Civic Duty", Location = "Cape Town City Hall", ImageUrl = "/images/city-hall.jpg", Priority = 3 },
                new Event { Id = 3, Title = "Kirstenbosch Summer Concerts", Description = "Enjoy an evening of live music with local artists.", Date = DateTime.Now.AddDays(12), Category = "Music & Culture", Location = "Kirstenbosch Gardens", ImageUrl = "/images/concert.jpg", Priority = 5 },
                new Event { Id = 4, Title = "Sea Point Promenade Parkrun", Description = "Weekly 5km run along the beautiful Sea Point coast.", Date = DateTime.Now.AddDays(4), Category = "Health & Wellness", Location = "Sea Point Promenade", ImageUrl = "/images/parkrun.jpg", Priority = 5 },
                new Event { Id = 5, Title = "Greenmarket Square Flea Market", Description = "Explore unique crafts, clothing, and food from local vendors.", Date = DateTime.Now.AddDays(5), Category = "Community Market", Location = "Greenmarket Square", ImageUrl = "/images/market.jpg", Priority = 5 },
                new Event { Id = 6, Title = "First Thursdays Art Walk", Description = "Galleries and cultural attractions in the city centre stay open late.", Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 5).AddMonths(1), Category = "Music & Culture", Location = "Cape Town CBD", ImageUrl = "/images/art-gallery.jpg", Priority = 3 },
                new Event { Id = 7, Title = "Newlands Ward 58 Community Meeting", Description = "Join your local councillor to discuss community safety.", Date = DateTime.Now.AddDays(20), Category = "Civic Duty", Location = "Newlands Community Hall", ImageUrl = "/images/community-meeting.jpg", Priority = 3 },
                new Event { Id = 9, Title = "Oranjezicht City Farm Market Day", Description = "A farmer's market for independent local farmers and artisanal food producers.", Date = DateTime.Now.AddDays(11), Category = "Community Market", Location = "V&A Waterfront", ImageUrl = "/images/farm-market.jpg", Priority = 4 },
                new Event { Id = 10, Title = "Roadworks on M3 Highway", Description = "Scheduled maintenance will cause lane closures on the M3 near UCT.", Date = DateTime.Now.AddDays(30), Category = "Public Service Announcement", Location = "M3 Highway", ImageUrl = "/images/roadworks.jpg", Priority = 3 },
                new Event { Id = 11, Title = "Blouberg Beach Cleanup", Description = "Volunteer to help keep one of our most scenic beaches clean.", Date = DateTime.Now.AddDays(19), Category = "Civic Duty", Location = "Bloubergstrand", ImageUrl = "/images/beach-cleanup.jpg", Priority = 4 },
                new Event { Id = 12, Title = "Cape Town Jazz Festival", Description = "Africa's grandest gathering celebrating the art of jazz.", Date = DateTime.Now.AddDays(45), Category = "Music & Culture", Location = "CTICC", ImageUrl = "/images/jazz-festival.png", Priority = 3 },
                new Event { Id = 13, Title = "Library Reading Hour for Kids", Description = "A fun and interactive reading session for children aged 5-8.", Date = DateTime.Now.AddDays(10), Category = "Community", Location = "Sea Point Library", ImageUrl = "/images/library.jpg", Priority = 5 },
                new Event { Id = 14, Title = "Free Yoga in the Park", Description = "A free weekly yoga session open to all fitness levels.", Date = DateTime.Now.AddDays(11), Category = "Health & Wellness", Location = "De Waal Park", ImageUrl = "/images/yoga.jpg", Priority = 5 }
            };

            foreach (var ev in events)
            {
                var uniqueKey = ev.Date.AddTicks(ev.Id);
                GlobalData.EventsByDate.Add(uniqueKey, ev);
                GlobalData.UniqueEventCategories.Add(ev.Category);
                GlobalData.FeaturedEvents.Enqueue(ev);
            }
        }

        // This new method seeds all the data for Part 3.
        private static void SeedServiceRequests()
        {
            // Use the BST to check if data already exists.
            if (GlobalData.RequestBST.Find(1001) != null) return;

            var requests = new List<ServiceRequest>
            {
                new ServiceRequest { Id = 1001, Title = "Burst Water Pipe", Description = "Major leak on Main Rd.", Location = "Sea Point", Status = "In Progress", Urgency = 1, DateSubmitted = DateTime.Now.AddDays(-2), ImageUrl = "/images/water-pipes-burst.jpg" },
                new ServiceRequest { Id = 1002, Title = "Street Light Out", Description = "Pole 45B is dark.", Location = "Woodstock", Status = "Submitted", Urgency = 5, DateSubmitted = DateTime.Now.AddDays(-5), ImageUrl = "/images/street-light-out.jpg" },
                new ServiceRequest { Id = 1003, Title = "Pothole Repair", Description = "Deep pothole causing tire damage.", Location = "Claremont", Status = "Submitted", Urgency = 3, DateSubmitted = DateTime.Now.AddDays(-1), ImageUrl = "/images/pothole.jpg" },
                new ServiceRequest { Id = 1004, Title = "Blocked Storm Drain", Description = "Flooding risk near school.", Location = "Rondebosch", Status = "Assigned", Urgency = 2, DateSubmitted = DateTime.Now.AddDays(-3), ImageUrl = "/images/storm-drain.jpg" },
                new ServiceRequest { Id = 1005, Title = "Illegal Dumping", Description = "Furniture dumped in park.", Location = "Green Point", Status = "Submitted", Urgency = 4, DateSubmitted = DateTime.Now.AddDays(-4), ImageUrl = "/images/illegal-dumping.jpg" },
                new ServiceRequest { Id = 1006, Title = "Graffiti Removal", Description = "Tagging on library wall.", Location = "City Bowl", Status = "Resolved", Urgency = 5, DateSubmitted = DateTime.Now.AddDays(-10), ImageUrl = "/images/graffiti.jpg" },
                new ServiceRequest { Id = 1007, Title = "Traffic Signal Failure", Description = "Intersection lights flashing red.", Location = "Observatory", Status = "In Progress", Urgency = 1, DateSubmitted = DateTime.Now, ImageUrl = "/images/traffic-signal.jpg" },
                new ServiceRequest { Id = 1008, Title = "Fallen Tree Branch", Description = "Blocking sidewalk.", Location = "Newlands", Status = "Submitted", Urgency = 3, DateSubmitted = DateTime.Now.AddDays(-1), ImageUrl = "/images/fallen-tree.jpg" },
                new ServiceRequest { Id = 1009, Title = "Water Supply Disruption", Description = "No water in block B.", Location = "Gardens", Status = "In Progress", Urgency = 1, DateSubmitted = DateTime.Now, ImageUrl = "/images/water-pipes.jpg" },
                new ServiceRequest { Id = 1010, Title = "Damaged Sidewalk", Description = "Cracked paving stones.", Location = "Mowbray", Status = "Submitted", Urgency = 4, DateSubmitted = DateTime.Now.AddDays(-6), ImageUrl = "/images/sidewalk.jpg" },
                new ServiceRequest { Id = 1011, Title = "Overgrown Verge", Description = "Grass obstructing view.", Location = "Pinelands", Status = "Scheduled", Urgency = 5, DateSubmitted = DateTime.Now.AddDays(-7), ImageUrl = "/images/overgrown-verge.jpg" },
                new ServiceRequest { Id = 1012, Title = "Leaking Fire Hydrant", Description = "Wasting water.", Location = "Salt River", Status = "Submitted", Urgency = 2, DateSubmitted = DateTime.Now.AddDays(-2), ImageUrl = "/images/fire-hydrant.jpg" },
                new ServiceRequest { Id = 1013, Title = "Uncollected Refuse", Description = "Bin collection missed.", Location = "Vredehoek", Status = "Resolved", Urgency = 3, DateSubmitted = DateTime.Now.AddDays(-8), ImageUrl = "/images/refuse.jpg" },
                new ServiceRequest { Id = 1014, Title = "Broken Park Swing", Description = "Chain snapped on swing.", Location = "Tamboerskloof", Status = "Submitted", Urgency = 4, DateSubmitted = DateTime.Now.AddDays(-3), ImageUrl = "/images/park-swing.jpg" },
                new ServiceRequest { Id = 1015, Title = "Road Sign Damaged", Description = "Stop sign bent over.", Location = "Maitland", Status = "Submitted", Urgency = 2, DateSubmitted = DateTime.Now.AddDays(-5), ImageUrl = "/images/road-sign.jpg" }
            };

            foreach (var req in requests)
            {
                // Add to the Binary Search Tree for finding by ID
                GlobalData.RequestBST.Add(req);

                // Add to the Min-Heap for organizing by urgency
                GlobalData.RequestHeap.Add(req);

                // Add to the Graph as a node
                GlobalData.RequestGraph.AddNode(req);
            }

            // I'm simulating a few dependencies here to show how the graph works.
            var r1001 = requests.First(r => r.Id == 1001);
            var r1003 = requests.First(r => r.Id == 1003);
            var r1007 = requests.First(r => r.Id == 1007);
            var r1015 = requests.First(r => r.Id == 1015);

            // Example: Repairing the pothole (1003) can't start until the burst pipe (1001) is fixed.
            GlobalData.RequestGraph.AddEdge(r1003, r1001);

            // Another dependency: the damaged road sign is related to the traffic signal failure.
            GlobalData.RequestGraph.AddEdge(r1015, r1007);
        }
    }
}