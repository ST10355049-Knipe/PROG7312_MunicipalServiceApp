# Municipal Services Application - Part 1

This repository contains Part 1 of my final year project for the PROG7312 module. The goal is to develop a proof-of-concept ASP.NET Core MVC application designed to streamline municipal service reporting within a South African context. This first part establishes the core application structure and implements the "Report an Issue" feature.

Youtube Video Link: https://youtu.be/smOUiMm-yqU

## Key Features Implemented (Part 1)

* **Professional User Interface:** A modern, responsive, multi-section landing page and a well-structured form page, designed with inspiration from official government websites.
* **Issue Reporting Functionality:** A fully functional issue reporting form with server-side validation. Users can provide a location, select a category, write a description, and attach media.
* **Custom Data Structure:** All submitted issue reports are stored in memory using a custom-built generic Linked List, adhering to the project's core technical constraints.
* **User Engagement Strategy:** The "Community-Verified Reporting with Trusted Contributor Badges" strategy is seamlessly integrated into the UI to encourage user participation, as per the research component of the project.

---

## Core Technical Requirements & Constraints

A primary requirement of this project is to demonstrate a strong understanding of fundamental data structures. As such, no built-in .NET collections like `List<T>` or arrays have been used for data storage. All user-submitted data is managed by a custom-built generic `CustomLinkedList<T>` class.

The application is built using the Model-View-Controller (MVC) architectural pattern to ensure a clean separation of concerns between the data, logic, and presentation layers.

## Technology Stack

* **Backend:** C#, .NET 8, ASP.NET Core MVC
* **Frontend:** HTML5, CSS3, Bootstrap 5
* **Icons:** Font Awesome

---

## Setup and Running the Project

### Prerequisites

* .NET 8.0 SDK
* Visual Studio 2022 (or a compatible IDE/code editor)

### Instructions

1.  **Clone the Repository:**
    ```bash
    git clone [your-repository-url]
    ```
2.  **Open in Visual Studio:**
    Navigate to the project folder and open the `.sln` file in Visual Studio.
3.  **Run the Application:**
    Press `F5` or the "Start" button in Visual Studio to build and run the project. The application will launch in your default web browser.

---

## How to Use the Application

1.  The application opens on the **Main Menu / Landing Page**, which provides an overview of the portal's features.
2.  To report a new issue, click on the **"Report an Issue Now"** button in the hero section or the **"Go to Form"** button on the corresponding card.
3.  On the **"Report a New Community Issue"** page, fill out the required fields: Location, Category, and Description.
4.  You can optionally attach a photo or video using the "Choose File" button.
5.  Click **"Submit Issue"**. A success message will appear at the top of the page, and the user engagement strategy is explained in the "Your Impact" section on the right.

## References

Coyier, C., 2024. [*A Complete Guide to Grid*](https://css-tricks.com/snippets/css/complete-guide-grid/). [online] CSS-Tricks. Available at: <https://css-tricks.com/snippets/css/complete-guide-grid/> [Accessed 09 September 2025].

Fonticons, Inc., 2025. [*Font Awesome*](https://fontawesome.com/). [online] Available at: <https://fontawesome.com/> [Accessed 09 September 2025].

GeeksforGeeks, 2024. [*Linked List Implementation in C#*](https://www.geeksforforgeeks.org/c-sharp/linked-list-implementation-in-c-sharp/). [online] Available at: <https://www.geeksforforgeeks.org/c-sharp/linked-list-implementation-in-c-sharp/> [Accessed 08 September 2025].

Microsoft, 2025. [*C# Programming Guide*](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/). [online] Microsoft Learn. Available at: <https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/> [Accessed 08 September 2025].

Microsoft, 2025. [*Generics in C#*](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics). [online] Microsoft Learn. Available at: <https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics> [Accessed 08 September 2025].

Microsoft, 2025. [*Introduction to ASP.NET Core MVC*](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview). [online] Microsoft Learn. Available at: <https://learn.microsoft.com/en-us/aspnet/core/mvc/overview> [Accessed 08 September 2025].

The Bootstrap Team, 2025. [*Introduction · Bootstrap v5.3*](https://getbootstrap.com/docs/5.3/getting-started/introduction/). [online] Available at: <https://getbootstrap.com/docs/5.3/getting-started/introduction/> [Accessed 10 September 2025].

## Author

* **Name:** Liam Knipe
* **Student ID:** ST10355049
