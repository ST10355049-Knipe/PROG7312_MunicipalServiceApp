using PROG7312_MunicipalServiceApp.DataStructures;
using PROG7312_MunicipalServiceApp.Models;

namespace PROG7312_MunicipalServiceApp
{
    // Acts as a centralized in-memory data store for the application's lifecycle.
    public static class GlobalData
    {
        // Stores all user-submitted issue reports from Part 1.
        public static CustomLinkedList<IssueReport> IssueReports { get; } = new CustomLinkedList<IssueReport>();

        // Primary storage for events, automatically sorted by date (the key).
        public static CustomSortedDictionary<DateTime, Event> EventsByDate { get; } = new CustomSortedDictionary<DateTime, Event>();

        // Stores unique event categories for populating search filters efficiently.
        public static CustomSet<string> UniqueEventCategories { get; } = new CustomSet<string>();

        // Manages high-priority or featured events.
        public static CustomPriorityQueue<Event> FeaturedEvents { get; } = new CustomPriorityQueue<Event>();

        // Tracks user search history to power the recommendation engine.
        public static CustomLinkedList<string> UserSearchHistory { get; } = new CustomLinkedList<string>();
    }
}