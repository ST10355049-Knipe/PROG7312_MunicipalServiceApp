using PROG7312_MunicipalServiceApp.DataStructures;
using PROG7312_MunicipalServiceApp.Models;

namespace PROG7312_MunicipalServiceApp
{
    public class GlobalData
    {
        // I've created a static property here to act as a simple in-memory 'database'. 
        // All issue reports will be stored in this single linked list for the lifetime of the application.
        public static CustomLinkedList<IssueReport> IssueReports { get; } = new CustomLinkedList<IssueReport>();
    }
}
