namespace PROG7312_MunicipalServiceApp.Models
{
    public class LocalEventsViewModel
    {
        public List<Event> DisplayEvents { get; set; }

        public List<Event> RecommendedEvents { get; set; }

        public List<Event> FeaturedEvents { get; set; }

        public string FavoriteCategory { get; set; }

        public int SearchCount { get; set; }

    }
}
