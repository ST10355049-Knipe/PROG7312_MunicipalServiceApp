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

## References & Resources

* **[C# Programming Guide](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/)**: The official Microsoft documentation for the C# language, used as the primary source for language syntax and features.
* **[Introduction to ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview)**: The official guide for the ASP.NET Core MVC framework, explaining the architecture used in this project.
* **[Linked List Implementation in C#](https://www.geeksforgeeks.org/c-sharp/linked-list-implementation-in-c-sharp/)**: A tutorial explaining the theory and implementation of linked lists, directly relevant to the custom data structure built for this project.
* **[Generics in C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics)**: Official documentation explaining the concept of generics, which were used to create the reusable `CustomLinkedList<T>`.
* **[Bootstrap 5 Documentation](https://getbootstrap.com/docs/5.3/getting-started/introduction/)**: The official documentation for the Bootstrap framework, used for all frontend components, styling, and the responsive grid system.
* **[A Complete Guide to CSS Grid](https://css-tricks.com/snippets/css/complete-guide-grid/)**: An industry-standard guide to the CSS Grid layout model, which was used to provide a robust page structure and fix the sticky footer issue.
* **[Font Awesome](https://fontawesome.com/)**: The icon library used to add professional iconography to the user interface.

## Author

* **Name:** Liam Knipe
* **Student ID:** ST10355049
