using Microsoft.AspNetCore.Mvc;
using PROG7312_MunicipalServiceApp.Models;
using System.Diagnostics;

namespace PROG7312_MunicipalServiceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ReportIssue()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReportIssue(IssueReport issue, IFormFile? mediaFile)
        {
            if (!ModelState.IsValid)
            {
                return View(issue);
            }

            
            if (mediaFile != null && mediaFile.Length > 0)
            {
                issue.MediaFilePath = $"user_upload_{mediaFile.FileName}";
            }

            issue.Timestamp = DateTime.Now;

            GlobalData.IssueReports.Add(issue);

            TempData["SuccessMessage"] = "Thank you, Citizen Reporter! Your issue has been submitted successfully. Keep contributing to earn badges!";

            return RedirectToAction("ReportIssue");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
