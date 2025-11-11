using System.Collections.Generic;

namespace PROG7312_MunicipalServiceApp.Models
{
    // This model packages up all the data needed for the Service Request Status page.
    public class ServiceRequestViewModel
    {
        // This will hold the single most urgent request from our heap.
        public ServiceRequest MostUrgentRequest { get; set; }

        // This will hold the complete list of all requests from our BST.
        public List<ServiceRequest> AllRequests { get; set; }

        public string SearchedId { get; set; } // Keeps the search box filled

        public ServiceRequest SearchedRequest { get; set; } // Holds the found request
    }
}
