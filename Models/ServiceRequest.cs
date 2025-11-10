using System;

namespace PROG7312_MunicipalServiceApp.Models
{
    // Simple interface im creating that guarantees any object using it has an 'Id' property.
    // My BinarySearchTree will use this to compare nodes.
    public interface IIdentifiable
    {
        int Id { get; }
    }

    // Simple interface im creating that guarantees any object using it has an 'Urgency' property.
    // My BinaryHeap will use this to organise itself.
    public interface IPrioritizableByUrgency
    {
        int Urgency { get; }
    }

    // This is the main model for a service request.
    // It implements my two new interfaces, so I can store it in my new data structures.
    public class ServiceRequest : IIdentifiable, IPrioritizableByUrgency
    {
        public int Id { get; set; } // The unique Request ID (e.g., 1001, 1002)
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; } // e.g. "Submitted", "In Progress", "Resolved"
        public int Urgency { get; set; }  // A priority number (e.g. 1 = High, 5 = Low)
        public DateTime DateSubmitted { get; set; }
        public string ImageUrl { get; set; }
    }
}
