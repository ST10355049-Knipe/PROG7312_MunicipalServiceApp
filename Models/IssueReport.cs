using System.ComponentModel.DataAnnotations;


namespace PROG7312_MunicipalServiceApp.Models
{
    public class IssueReport
    {
        [Required(ErrorMessage = "Please provide the location of the issue.")]
        public string Location { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Please provide a detailed description.")]
        public string Description { get; set; }

        public string? MediaFilePath { get; set; }

        public DateTime Timestamp { get; set; }

    }
}
