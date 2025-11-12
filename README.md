# Municipal Services Application - Portfolio of Evidence (POE)

**Student Name:** Liam Knipe
**Student ID:** ST10355049
**Module:** PROG7312

---

## 📖 Project Overview

The Municipal Services Application is a comprehensive software solution designed to streamline communication between citizens and the City of Cape Town municipality. Developed as a final-year portfolio project, the application serves as a centralized portal for reporting infrastructure issues, tracking service request status, and discovering local community events.

The project was built over three parts, evolving from a basic reporting tool into a fully-featured platform powered by advanced, custom-built data structures and algorithms.

### Application Screenshots

**Application Home Page:**

<img width="1279" height="455" alt="image" src="https://github.com/user-attachments/assets/0f4fd18a-ae21-4b01-8bcb-9d3d46debfb4" />
<img width="1196" height="678" alt="image" src="https://github.com/user-attachments/assets/2097a2db-d3e8-4a46-8c96-95ca7b0f57a9" />
<img width="1120" height="762" alt="image" src="https://github.com/user-attachments/assets/4a992b62-7ad4-4d97-ba66-dbbe38845988" />



**Part 1: Report Issue Page:**

<img width="1237" height="637" alt="image" src="https://github.com/user-attachments/assets/28123379-048e-4c09-8117-4da3389b4f5d" />



**Part 2: Local Events Page:**

<img width="1229" height="549" alt="image" src="https://github.com/user-attachments/assets/cbce61b8-6c17-4dbc-a5c5-35828142e259" />
<img width="1424" height="744" alt="image" src="https://github.com/user-attachments/assets/b1a26f55-672d-4bbf-b901-def1016a985e" />



**Part 3: Service Request Status Page:**

<img width="1277" height="646" alt="image" src="https://github.com/user-attachments/assets/fedb33dc-d298-4299-bf53-17195118b674" />
<img width="1314" height="725" alt="image" src="https://github.com/user-attachments/assets/f216b99e-f56c-4211-935c-2f652dace5fc" />

---

## 🛠️ Technology Stack

* **Framework:** ASP.NET Core MVC (.NET 8.0)
* **Language:** C#
* **Frontend:** HTML5, CSS3, Bootstrap 5, JavaScript
* **Data Structures:** Custom implementations (no built-in collections used for core logic)
* **Version Control:** Git & GitHub

---

## 🚀 Features & Functionality

### Part 1: Issue Reporting
The foundation of the application, allowing citizens to act as the "eyes and ears" of the municipality.

* **Report Submission:** Users can submit detailed reports including location, category, and description.
* **File Attachments:** Supports media attachments (images/documents) for evidence.
* **Gamification:** Integrated "Citizen Reporter" badges to encourage engagement.
* **Data Storage:** Uses a **Custom Linked List** to store all reports in memory.

### Part 2: Local Events & Announcements
A dynamic dashboard for community engagement.

* **Featured Events:** High-priority announcements are showcased in a dedicated section.
* **Search & Filter:** Users can search events by title and filter by unique categories.
* **Recommendation Engine:** A smart algorithm analyses user search patterns to suggest relevant events based on their interests.
* **Data Structures:** Powered by a **Sorted Dictionary** (storage), **Set** (categories), and **Priority Queue** (featured events).

### Part 3: Service Request Status (Final POE)
The advanced tracking system for monitoring service delivery.

* **Status Tracking:** Users can view a list of all active requests and their current status (e.g. "In Progress", "Resolved").
* **Search by ID:** A fast lookup feature to find a specific request using its unique ID.
* **Dependency Tracking:** An advanced feature that visualizes relationships between requests (e.g. showing that a Pothole Repair is blocked by a Burst Pipe).
* **Data Structures:** Powered by a **Binary Search Tree** (fast lookups), **Min-Heap** (urgency prioritisation), and **Graph** (dependency modeling).

---

## 🔄 Changelog: Updates Based on Feedback

As part of the continuous improvement process, the following updates were implemented in Part 3 to address feedback received from the Part 2 submission.

### 1. Implementation of Hash Tables & Sets
> **Feedback:** "Hash tables and sets need to be implemented."

**Action Taken:** I built a `CustomHashTable` class from scratch using an array and chaining for collision resolution. This hash table was then used as the underlying storage mechanism for the `CustomSet` and the `CustomGraph`, significantly improving lookup performance from O(n) to O(1) on average.

### 2. Implementation of Stacks
> **Feedback:** "Stacks need to be implemented."

**Action Taken:** I implemented a generic `CustomStack<T>` class. This LIFO (Last-In, First-Out) structure was added to the project's data structure library to fulfill the technical requirement and is available for use in navigation history features.

---

## 🧠 Data Structure Explanations

A core requirement of this project was to implement custom data structures to manage data efficiency. Below is an explanation of each structure used and its specific role in the application.

### 1. Binary Search Tree (BST)
* **What it is:** A tree data structure where each node has at most two children, arranged such that the left child is smaller and the right child is larger than the parent.
* **Role in App:** Used in the **Service Request Status** feature to store all service requests.
* **Efficiency:** The BST allows us to search for a specific Request ID in **O(log n)** time. This is significantly faster than searching through a standard list (O(n)), making it the ideal choice for the "Track Request" search bar feature.

### 2. Min-Heap (Priority Queue)
* **What it is:** A binary tree-based structure where the parent node is always smaller (higher priority) than its children.
* **Role in App:** Used to manage the **urgency** of service requests.
* **Efficiency:** The heap allows us to access the request with the highest priority (lowest urgency number) in **O(1)** constant time. This ensures the "Highest Priority Request" alert on the status page always displays the most critical issue instantly, without needing to sort the entire list.

### 3. Graph
* **What it is:** A collection of nodes connected by edges, used to model relationships.
* **Role in App:** Used to model **dependencies** between service requests (e.g. Request A must be finished before Request B).
* **Efficiency:** The graph structure allows us to traverse connections efficiently. When a user views a request, we can instantly traverse its edges to find and display any "blocking" requests, providing essential context that a simple list could not offer.

### 4. Hash Table
* **What it is:** A structure that maps keys to values using a hash function for direct access.
* **Role in App:** Used as the internal storage for the **Graph** nodes and the **Set** of event categories.
* **Efficiency:** It provides **O(1)** average time complexity for insertions and lookups. This is crucial for the Graph, where we need to instantly find if a node exists before adding an edge to it.

---

## 💻 How to Run the Application

### Prerequisites
* **Visual Studio 2022** (or compatible IDE with .NET 8 support)
* **.NET 8.0 SDK** installed on your machine.

### Steps
1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/ST10355049-Knipe/PROG7312_MunicipalServiceApp.git](https://github.com/ST10355049-Knipe/PROG7312_MunicipalServiceApp.git)
    ```
2.  **Open in Visual Studio:** Navigate to the cloned folder and double-click the `.sln` solution file.
3.  **Build the Solution:** Go to `Build > Build Solution` (or press `Ctrl+Shift+B`) to restore packages and compile the code.
4.  **Run the Project:** Press `F5` or click the green "Start" button. The application will launch in your default web browser.

---

## 📚 Bibliography

* Coyier, C., 2024. *A Complete Guide to Grid*. [online] CSS-Tricks. Available at: https://css-tricks.com/snippets/css/complete-guide-grid/ [Accessed 09 September 2025].
* Fonticons, Inc., 2025. *Font Awesome*. [online] Available at: https://fontawesome.com/ [Accessed 09 September 2025].
* GeeksforGeeks, 2024. *Linked List Implementation in C#*. [online] Available at: https://www.geeksforgeeks.org/c-sharp/linked-list-implementation-in-c-sharp/ [Accessed 08 September 2025].
* Microsoft, 2025. *C# Programming Guide*. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/ [Accessed 08 September 2025].
* Microsoft, 2025. *Generics in C#*. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics [Accessed 08 September 2025].
* Microsoft, 2025. *Introduction to ASP.NET Core MVC*. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/overview [Accessed 08 September 2025].
* The Bootstrap Team, 2025. *Introduction · Bootstrap v5.3*. [online] Available at: https://getbootstrap.com/docs/5.3/getting-started/introduction/ [Accessed 10 September 2025].
* C# Corner, 2023. *Learn About Priority Queue In C# With Examples*. [online] Available at: https://www.c-sharpcorner.com/article/learn-about-priority-queue-in-c-sharp-with-examples/ [Accessed 14 October 2025].
* GeeksforGeeks, 2024. *C# | SortedDictionary Class*. [online] Available at: https://www.geeksforgeeks.org/c-sharp/sorteddictionary-class-in-c-sharp/ [Accessed 14 October 2025].
* Google, 2025. *Gemini Language Model Consultation*. [online] Mountain View, CA: Google. The model was used as a tool to generate boilerplate JavaScript code for implementing a Bootstrap modal with a Fetch API call, based on prompts describing the desired functionality (e.g., "on modal open, fetch data from a controller endpoint and populate the modal's HTML"). Assistance was also provided in debugging CSS layout conflicts. [Accessed 15 October 2025].
* Microsoft, 2025. *Add a model to an ASP.NET Core MVC app*. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-9.0&tabs=visual-studio [Accessed 15 October 2025].
* Microsoft, 2025. *IComparable Interface*. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=net-9.0 [Accessed 14 October 2025].
* Microsoft, 2025. *Introduction to LINQ Queries (C#)*. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries [Accessed 14 October 2025].
* Microsoft, 2025. *Model validation in ASP.NET Core MVC*. [online] Microsoft Learn. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-9.0 [Accessed 15 October 2025].
* TutorialsPoint, 2025. *Sets in C#*. [online] Available at: https://www.tutorialspoint.com/sets-in-chash [Accessed 15 October 2025].
* MDN Web Docs, 2025. *DOMContentLoaded event*. [online] Mozilla. Available at: https://developer.mozilla.org/en-US/docs/Web/API/Document/DOMContentLoaded_event [Accessed 15 October 2025].
* MDN Web Docs, 2025. *Using the Fetch API*. [online] Mozilla. Available at: https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch [Accessed 15 October 2025].
* The Bootstrap Team, 2025. *Modal - Bootstrap v5.3*. [online] Available at: https://getbootstrap.com/docs/5.3/components/modal/ [Accessed 15 October 2025].
* Google, 2025. *Gemini Language Model Consultation*. [online] Mountain View, CA: Google. The model provided boilerplate logic for implementing a Min-Heap using an array-based approach, specifically assisting with the index calculations for parent and child nodes. [Accessed 11 November 2025].
* Rubio, F., 2024. *The 2 Most Popular Graph Traversal Algorithm*. [online] Graphable.ai. Available at: https://graphable.ai/blog/best-graph-traversal-algorithms/ [Accessed 12 November 2025].
* GeeksforGeeks, 2025. *Array representation of Binary Heap*. [online] Available at: https://www.geeksforgeeks.org/dsa/array-representation-of-binary-heap/ [Accessed 11 November 2025].
* GeeksforGeeks, 2025. *Binary Search Tree (BST) Traversals – Inorder, Preorder, Post Order*. [online] Available at: https://www.geeksforgeeks.org/dsa/binary-search-tree-traversal-inorder-preorder-post-order/ [Accessed 12 November 2025].
* Programiz, 2025. *Graph Adjacency List*. [online] Available at: https://www.programiz.com/dsa/graph-adjacency-list [Accessed 12 November 2025].
* Kini, M, 2020. *Binary Heap In C#*. [online] C# Corner. Available at: https://www.c-sharpcorner.com/article/binary-heap-in-c-sharp/ [Accessed 11 November 2025].
* Google, 2025. *Gemini Language Model Consultation*. [online] Mountain View, CA: Google. Assistance was sought to debug a logical error in the Graph implementation where directed edges were being created in the reverse order, preventing the dependency traversal algorithm from functioning correctly. [Accessed 11 November 2025].
