using PROG7312_MunicipalServiceApp.DataStructures;
using PROG7312_MunicipalServiceApp.Models;


namespace PROG7312_MunicipalServiceApp
{
    public class GlobalData
    {
        // I've created a static property here to act as a simple in-memory 'database'. 
        // All issue reports will be stored in this single linked list for the lifetime of the application.
        public static CustomLinkedList<IssueReport> IssueReports { get; } = new CustomLinkedList<IssueReport>();

        // A Sorted Dictionary will be our primary data store for events.
        // It's required by the rubric and is efficient for organizing events by date.
        public static CustomSortedDictionary<DateTime, Event> EventsByDate { get; } = new CustomSortedDictionary<DateTime, Event>();

        // A Set is required to efficiently store and retrieve unique event categories for our search filter.
        public static CustomSet<string> UniqueEventCategories { get; } = new CustomSet<string>();

        // A Priority Queue is required and is a great way to manage and display "featured" or important events first.
        public static CustomPriorityQueue<Event> FeaturedEvents { get; } = new CustomPriorityQueue<Event>();
    }
}
