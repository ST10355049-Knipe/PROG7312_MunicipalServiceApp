using PROG7312_MunicipalServiceApp.DataStructures;
using PROG7312_MunicipalServiceApp.Models;

namespace PROG7312_MunicipalServiceApp
{
    public class GlobalData
    {
        public static CustomLinkedList<IssueReport> IssueReports { get; } = new CustomLinkedList<IssueReport>();
    }
}
