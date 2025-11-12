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

            // Using TempData to show a success message on the next page load. Its a one time message.
            TempData["SuccessMessage"] = "Thank you, Citizen Reporter! Your issue has been submitted successfully. Keep contributing to earn badges!";

            // Redirect back to the ReportIssue page to show a clean form and prevent resubmission on refresh.
            return RedirectToAction("ReportIssue");
        }

        [HttpGet]
        public IActionResult LocalEvents(string searchQuery, string category, string sortBy = "date_desc")
        {
            // Use the Priority Queue to get the top 4 events for the featured carousel.
            var featuredEvents = GlobalData.FeaturedEvents.PeekTop(4);

            // Start with the full list of events from the main dictionary.
            var allEvents = GlobalData.EventsByDate.GetAllValues();
            ViewData["CurrentSearch"] = searchQuery; // Keeps the search input populated after search.

            // Apply filters if the user provided any input.
            if (!String.IsNullOrEmpty(category))
            {
                GlobalData.UserSearchHistory.Add(category);
                allEvents = allEvents.Where(e => e.Category == category).ToList();
            }
            if (!String.IsNullOrEmpty(searchQuery))
            {
                allEvents = allEvents.Where(e => e.Title.ToLower().Contains(searchQuery.ToLower())).ToList();
            }

            // Apply the selected sort order. Default is newest date first.
            switch (sortBy)
            {
                case "date_asc": allEvents = allEvents.OrderBy(e => e.Date).ToList(); break;
                case "title_asc": allEvents = allEvents.OrderBy(e => e.Title).ToList(); break;
                case "title_desc": allEvents = allEvents.OrderByDescending(e => e.Title).ToList(); break;
                default: allEvents = allEvents.OrderByDescending(e => e.Date).ToList(); break;
            }

            // --- Recommendation Algorithm ---
            var recommendedEvents = new List<Event>();
            string favoriteCategory = null;
            int searchCount = 0;
            var searchHistory = GlobalData.UserSearchHistory.GetAllNodesAsList();

            if (searchHistory.Any())
            {
                // Find the user's most searched category using LINQ.
                var favoriteGroup = searchHistory.GroupBy(c => c).OrderByDescending(g => g.Count()).FirstOrDefault();
                if (favoriteGroup != null)
                {
                    favoriteCategory = favoriteGroup.Key;
                    searchCount = favoriteGroup.Count();

                    // Get up to 3 events from that category that aren't already displayed.
                    recommendedEvents = GlobalData.EventsByDate.GetAllValues()
                        .Where(e => e.Category == favoriteCategory && !allEvents.Contains(e))
                        .Take(3).ToList();
                }
            }

            // Package all the necessary data into the ViewModel for the page.
            var viewModel = new LocalEventsViewModel
            {
                FeaturedEvents = featuredEvents,
                DisplayEvents = allEvents,
                RecommendedEvents = recommendedEvents,
                FavoriteCategory = favoriteCategory,
                SearchCount = searchCount
            };

            // Prepare ViewBag data for the filter and sort dropdowns.
            var categories = GlobalData.UniqueEventCategories.GetAllItems();
            ViewBag.Categories = new SelectList(categories);
            var sortOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "date_desc", Text = "Date (Newest)" },
                new SelectListItem { Value = "date_asc", Text = "Date (Oldest)" },
                new SelectListItem { Value = "title_asc", Text = "Title (A-Z)" },
                new SelectListItem { Value = "title_desc", Text = "Title (Z-A)" }
            };
            ViewBag.SortByList = new SelectList(sortOptions, "Value", "Text", sortBy);

            return View(viewModel);
        }

        // This is a special endpoint for my JavaScript to call.
        // It finds a single event by its ID and returns the data in JSON format,
        // which is perfect for dynamically loading content into the modal.
        [HttpGet]
        public IActionResult GetEventById(int id)
        {
            var eventData = GlobalData.EventsByDate.GetAllValues().FirstOrDefault(e => e.Id == id);
            if (eventData == null)
            {
                return NotFound();
            }
            return Json(eventData);
        }

        [HttpGet]
        public IActionResult ServiceRequestStatus(string searchId)
        {
            var mostUrgent = GlobalData.RequestHeap.Peek();
            var allRequests = GlobalData.RequestBST.GetAllRequests();
            ServiceRequest searchedRequest = null;
            var dependencies = new List<ServiceRequest>();

            // This is where we use our Binary Search Tree's Find method.
            if (!string.IsNullOrEmpty(searchId))
                
           {
                // Try to convert the string ID from the search box into an integer.
                if (int.TryParse(searchId, out int id))
                {
                    // Use the BST's fast Find method
                    searchedRequest = GlobalData.RequestBST.Find(id);

                    if (searchedRequest != null)
                    {
                        // If we found a request, use the graph to find its dependencies.
                        dependencies = GlobalData.RequestGraph.GetDependencies(searchedRequest);
                    }
                }
            }

            var viewModel = new ServiceRequestViewModel
            {
                MostUrgentRequest = mostUrgent,
                AllRequests = allRequests,
                SearchedRequest = searchedRequest, // Pass the found request
                SearchedId = searchId,             // Pass the original search term
                Dependencies = dependencies
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
