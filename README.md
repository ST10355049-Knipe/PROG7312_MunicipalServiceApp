# Municipal Services Application - Parts 1 & 2

This repository contains my submission for Parts 1 and 2 of the final year project for the PROG7312 module. The project is an ASP.NET Core MVC application designed to be a comprehensive portal for municipal service reporting and community engagement, specifically tailored for the City of Cape Town.

<img width="2536" height="874" alt="landingpic1" src="https://github.com/user-attachments/assets/518a13df-f63a-46b0-ade7-8bbbec6b2386" />
<img width="2006" height="1198" alt="landingpic2" src="https://github.com/user-attachments/assets/f176fd2c-1ef8-4be5-8fa4-9e047ceb1a94" />
<img width="1964" height="1271" alt="landingpic3" src="https://github.com/user-attachments/assets/d84a65d4-be04-4fe9-89a7-131c8c1985e1" />


---

## Technology Stack

* **Backend:** C#, .NET 8, ASP.NET Core MVC
* **Frontend:** HTML5, CSS3, Bootstrap 5
* **Icons:** Font Awesome
* **Core Data Structures:** Custom-built Linked List, Set, Sorted Dictionary, and Priority Queue

---

## Part 1: Issue Reporting

Part 1 established the core application and the "Report an Issue" feature.

### Key Features:

* **Professional UI:** A modern, responsive landing page and a structured, user-friendly form page.
* **Functional Reporting Form:** Allows users to submit detailed issue reports with location, category, description, and optional media attachments.
* **Custom Linked List:** All submitted reports are stored in memory using a custom-built generic `CustomLinkedList<T>`, adhering to project constraints.
* **User Engagement Strategy:** The "Community-Verified Reporting with Trusted Contributor Badges" strategy is explained and integrated directly into the reporting workflow.

<img width="2532" height="1301" alt="submitreportpic" src="https://github.com/user-attachments/assets/79e01eb1-b372-4343-afd1-fa369080fbbd" />


---

## Part 2: Local Events & Recommendation Engine

Part 2 expands the application's functionality by introducing a dynamic "Local Events & Announcements" page with advanced features.

### Key Features:

* **Event Display & Seeding:** The application starts by seeding 15+ sample events into the system. These are displayed on a professional, card-based UI.
* **Search, Filter & Sort:** The events page includes a full suite of tools allowing users to:
    * 🔍 **Search** for events by title.
    * 📂 **Filter** events by category.
    * ↕️ **Sort** events by date or title.
* **Smart Recommendation Engine:** A recommendation algorithm was developed to enhance user experience. It works by:
    1.  **Tracking** the categories a user filters by.
    2.  **Analyzing** this history to determine their most frequent preference.
    3.  **Suggesting** other relevant events from that category in a "Recommended for You" section.
* **Advanced Custom Data Structures:** This part's functionality is powered by several custom-built data structures:
    * **`CustomSortedDictionary<TKey, TValue>`:** Used as the primary storage for events, keeping them sorted chronologically by date.
    * **`CustomSet<T>`:** Used to efficiently manage the unique list of event categories for the filter dropdown.
    * **`CustomPriorityQueue<T>`:** Used to manage and prioritize "featured" or important events.

<img width="2522" height="829" alt="localeventsfinal" src="https://github.com/user-attachments/assets/07c7f1ae-3a9d-42f5-9a53-1fb586ef8862" />


<img width="1705" height="1251" alt="localeventsfinal2" src="https://github.com/user-attachments/assets/ebd80030-ba11-4c70-9375-32ddb877d906" />



---

## Setup and Running the Project

### Prerequisites

* .NET 8.0 SDK
* Visual Studio 2022 (or a compatible IDE)

### Instructions

1.  **Clone the Repository:**
    ```bash
    git clone [your-repository-url]
    ```

2.  **Open in Visual Studio:**
    Navigate to the project folder and open the `.sln` file.

3.  **Run the Application:**
    Press `F5` or the "Start" button to build and run the project.

---

## How to Use the Application

This guide provides a step-by-step walkthrough of the application's features as of the Part 2 submission.

### 1. The Landing Page

The application opens on the main landing page, which serves as the central hub. From here, you can:
* Get a high-level overview of the portal's purpose.
* Use the primary "Report an Issue Now" button in the hero section to navigate directly to the reporting form.
* Use the navigation cards or the top navigation bar to access different sections of the application.

### 2. Reporting an Issue (Part 1 Feature)

1.  Click on the **"Report an Issue"** or **"Go to Form"** button.
2.  On the reporting page, fill out the required fields: Location, Category, and a detailed Description.
3.  You can optionally attach a photo or video using the "Choose File" button.
4.  Click **"Submit Issue"**. A success message will appear at the top of the form. The "Your Impact" section on the right explains the next steps and the badge system.

### 3. Viewing and Interacting with Local Events (Part 2 Feature)

1.  From the homepage or the top navigation bar, click on **"Local Events"**.
2.  The page will load, displaying a full list of all sample events, sorted by the newest date first.
3.  You can use the interactive bar at the top to:
    * **Search:** Type into the "Search by event title..." box to find specific events.
    * **Filter:** Use the "All Categories" dropdown to view events from only one category.
    * **Sort:** Use the "Sort by" dropdown to organize events by newest/oldest date or by title (A-Z / Z-A).

### 4. Triggering the Smart Recommendation Engine

The recommendation engine is a key feature of Part 2 and requires user interaction to work.
1.  On the "Local Events" page, use the **category filter dropdown** to search for a specific category (e.g., "Civic Duty") and click "Search".
2.  The page will reload with the filtered results.
3.  **Repeat this process** a few times, searching for the same category or different ones.
4.  After a few searches, the system will identify your most frequent preference. A new **"Recommended For You"** section will automatically appear, suggesting other events from your favorite category.

---

## Code References & Explanations

This section provides a brief overview of the key technical implementations and architectural patterns used in this project.

### Custom Generic Data Structures

To adhere to the project's core requirement of not using built-in .NET collections, all data structures were implemented from scratch. The use of **generics** (`<T>`) makes these structures type-safe and reusable.

* **`CustomLinkedList<T>`:** The foundational structure used as the internal backing for all other collections.
* **`CustomSet<T>`:** Enforces uniqueness, used to manage the list of event categories for the filter dropdown.
* **`CustomSortedDictionary<TKey, TValue>`:** Maintains a collection of key-value pairs sorted by the key. This is used as the primary storage for events, keeping them organized chronologically.
* **`CustomPriorityQueue<T>`:** A queue that orders items based on a priority value, used here to manage "featured" events.

### ASP.NET Core MVC Architecture

The project is structured using the Model-View-Controller (MVC) pattern to ensure a clean separation of concerns:

* **Model (`.cs` files in `/Models`):** Defines the C# objects for our data (e.g., `IssueReport`, `Event`). Data annotations (`[Required]`) are used for server-side validation.
* **View (`.cshtml` files in `/Views`):** Uses Razor syntax to render the HTML user interface based on data from the controller. A `_Layout.cshtml` file provides a consistent template for all pages.
* **Controller (`HomeController.cs`):** Handles HTTP requests, processes form data, interacts with the data stores, and selects the appropriate view to return to the user.

### In-Memory State Management

With no database requirement, the application's state is managed in-memory via a `static GlobalData` class. This class holds a single, static instance of each data structure, ensuring data persists for the application's lifecycle and is accessible from any part of the application.

## References

Coyier, C., 2024. [*A Complete Guide to Grid*](https://css-tricks.com/snippets/css/complete-guide-grid/). [online] CSS-Tricks. Available at: <https://css-tricks.com/snippets/css/complete-guide-grid/> [Accessed 09 September 2025].

Fonticons, Inc., 2025. [*Font Awesome*](https://fontawesome.com/). [online] Available at: <https://fontawesome.com/> [Accessed 09 September 2025].

GeeksforGeeks, 2024. [*Linked List Implementation in C#*](https://www.geeksforforgeeks.org/c-sharp/linked-list-implementation-in-c-sharp/). [online] Available at: <https://www.geeksforforgeeks.org/c-sharp/linked-list-implementation-in-c-sharp/> [Accessed 08 September 2025].

Microsoft, 2025. [*C# Programming Guide*](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/). [online] Microsoft Learn. Available at: <https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/> [Accessed 08 September 2025].

Microsoft, 2025. [*Generics in C#*](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics). [online] Microsoft Learn. Available at: <https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics> [Accessed 08 September 2025].

Microsoft, 2025. [*Introduction to ASP.NET Core MVC*](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview). [online] Microsoft Learn. Available at: <https://learn.microsoft.com/en-us/aspnet/core/mvc/overview> [Accessed 08 September 2025].

The Bootstrap Team, 2025. [*Introduction · Bootstrap v5.3*](https://getbootstrap.com/docs/5.3/getting-started/introduction/). [online] Available at: <https://getbootstrap.com/docs/5.3/getting-started/introduction/> [Accessed 10 September 2025].

C# Corner, 2023. Learn About Priority Queue In C# With Examples. [online] Available at: https://www.c-sharpcorner.com/article/learn-about-priority-queue-in-c-sharp-with-examples/ [Accessed 14 October 2025].

GeeksforGeeks, 2024. C# | SortedDictionary Class. [online] Available at: https://www.geeksforgeeks.org/c-sharp/sorteddictionary-class-in-c-sharp/ [Accessed 14 October 2025].

Google, 2025. Gemini Language Model Consultation. [online] Mountain View, CA: Google. The model was used as a tool to generate boilerplate JavaScript code for implementing a Bootstrap modal with a Fetch API call, based on prompts describing the desired functionality (e.g., "on modal open, fetch data from a controller endpoint and populate the modal's HTML"). Assistance was also provided in debugging CSS layout conflicts. [Accessed 15 October 2025].

Microsoft, 2025. Add a model to an ASP.NET Core MVC app. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-9.0&tabs=visual-studio [Accessed 15 October 2025].

Microsoft, 2025. IComparable<T> Interface. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-9.0 [Accessed 14 October 2025].

Microsoft, 2025. Introduction to LINQ Queries (C#). [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries [Accessed 14 October 2025].

Microsoft, 2025. Model validation in ASP.NET Core MVC. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-9.0 [Accessed 15 October 2025].

TutorialsPoint, 2025. Sets in C#. [online] Available at: https://www.tutorialspoint.com/sets-in-chash [Accessed 15 October 2025].

MDN Web Docs, 2025. DOMContentLoaded event. [online] Mozilla. Available at: https://developer.mozilla.org/en-US/docs/Web/API/Document/DOMContentLoaded_event [Accessed 15 October 2025].

MDN Web Docs, 2025. Using the Fetch API. [online] Mozilla. Available at: https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch [Accessed 15 October 2025].

The Bootstrap Team, 2025. Modal - Bootstrap v5.3. [online] Available at: https://getbootstrap.com/docs/5.3/components/modal/ [Accessed 15 October 2025].

## Author

* **Name:** Liam Knipe
* **Student ID:** ST10355049
