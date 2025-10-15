using System.ComponentModel.DataAnnotations;


namespace PROG7312_MunicipalServiceApp.Models
{
    // This is my model for an issue report. It defines the structure of the data.
    public class IssueReport
    {
        // Adding some basic server-side validation here. The form wont be valid if these are empty.
        [Required(ErrorMessage = "Please provide the location of the issue.")]
        public string Location { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "Please provide a detailed description.")]
        public string Description { get; set; }

        // Making this nullable ('?') since the file upload is optional for the user.
        public string? MediaFilePath { get; set; }

        // This will be set by the server, not the user.
        public DateTime Timestamp { get; set; }

    }
}
