using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            // Just returns the main landing page.
            return View();
        }

        [HttpGet]
        public IActionResult ReportIssue()
        {
            // This action just displays the empty form for the user to fill out.
            return View();
        }

        // This attribute means this method will only handle POST requests, like from a form submission.
        [HttpPost]
        public IActionResult ReportIssue(IssueReport issue, IFormFile? mediaFile)
        {
            // First, check if the submitted data matches the validation rules in my IssueReport model.
            if (!ModelState.IsValid)
            {
                // If the model is not valid, return the view with the user's data.
                return View(issue);
            }

            // Handle the optional file upload.
            if (mediaFile != null && mediaFile.Length > 0)
            {
                // For now, I'm just storing the file name, when i implement the database i will store the file properly.
                issue.MediaFilePath = $"user_upload_{mediaFile.FileName}";
            }

            // Set the timestamp for when the report was submitted.
            issue.Timestamp = DateTime.Now;

            // Add the new issue report to my custom linked list data structure.
            GlobalData.IssueReports.Add(issue);

            // Using TempData to show a success message on the next page load. It's a one-time message.
            TempData["SuccessMessage"] = "Thank you, Citizen Reporter! Your issue has been submitted successfully. Keep contributing to earn badges!";

            // Redirect back to the ReportIssue page to show a clean form and prevent resubmission on refresh.
            return RedirectToAction("ReportIssue");
        }

        [HttpGet]
        public IActionResult LocalEvents(string searchQuery, string category, string sortBy = "date_desc")
        {
            var allEvents = GlobalData.EventsByDate.GetAllValues();
            ViewData["CurrentSearch"] = searchQuery;

            if (!String.IsNullOrEmpty(category))
            {
                GlobalData.UserSearchHistory.Add(category);
                allEvents = allEvents.Where(e => e.Category == category).ToList();
            }

            if (!String.IsNullOrEmpty(searchQuery))
            {
                allEvents = allEvents.Where(e => e.Title.ToLower().Contains(searchQuery.ToLower())).ToList();
            }

            // This switch statement applies the correct sorting based on the user's selection.
            switch (sortBy)
            {
                case "date_asc":
                    allEvents = allEvents.OrderBy(e => e.Date).ToList();
                    break;
                case "title_asc":
                    allEvents = allEvents.OrderBy(e => e.Title).ToList();
                    break;
                case "title_desc":
                    allEvents = allEvents.OrderByDescending(e => e.Title).ToList();
                    break;
                default: // Default case is "date_desc"
                    allEvents = allEvents.OrderByDescending(e => e.Date).ToList();
                    break;
            }

            var recommendedEvents = new List<Event>();
            var searchHistory = GlobalData.UserSearchHistory.GetAllNodesAsList();

            if (searchHistory.Any())
            {
                var favoriteCategory = searchHistory
                    .GroupBy(c => c)
                    .OrderByDescending(group => group.Count())
                    .Select(group => group.Key)
                    .FirstOrDefault();

                if (favoriteCategory != null)
                {
                    recommendedEvents = GlobalData.EventsByDate.GetAllValues()
                        .Where(e => e.Category == favoriteCategory && !allEvents.Contains(e))
                        .Take(3)
                        .ToList();
                }
            }

            var viewModel = new LocalEventsViewModel
            {
                DisplayEvents = allEvents,
                RecommendedEvents = recommendedEvents
            };

            var categories = GlobalData.UniqueEventCategories.GetAllItems();
            ViewBag.Categories = new SelectList(categories);
            ViewBag.SortBy = sortBy; // Pass sort selection back to the view

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
