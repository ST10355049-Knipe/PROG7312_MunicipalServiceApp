using PROG7312_MunicipalServiceApp.DataStructures;

namespace PROG7312_MunicipalServiceApp.Models
{
    public class Event : IPrioritizable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        // A lower number means higher priority (e.g. 1 is a featured event).
        public int Priority { get; set; }
    }
}
