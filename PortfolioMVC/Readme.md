# My Portfolio MVC

## About The Project

This project is a personal portfolio website developed using ASP.NET Core MVC.

The purpose of this application is to showcase my web development projects, provide links to my GitHub repositories, and demonstrate my understanding of MVC architecture, authentication, database operations, and responsive UI design.

---

## Features

- Hardcoded login system
- Portfolio homepage
- Project table of contents
- Project thumbnails
- GitHub repository links
- Project descriptions
- Individual project detail pages
- Comment section for each project
- SQLite database
- Responsive design
- Bootstrap styling
- Form validation

---

## Technologies Used

- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQLite
- HTML
- CSS
- Bootstrap
- JavaScript
- Git
- GitHub

---

## Project Structure

```text
PortfolioMVC
│
├── Controllers
│   ├── HomeController.cs
│   ├── AccountController.cs
│   └── ProjectsController.cs
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Models
│   ├── Project.cs
│   ├── Comment.cs
│   ├── LoginViewModel.cs
│   └── ProjectDetailsViewModel.cs
│
├── Views
│   ├── Account
│   │   └── Login.cshtml
│   │
│   ├── Home
│   │   └── Index.cshtml
│   │
│   ├── Projects
│   │   ├── Index.cshtml
│   │   └── Details.cshtml
│   │
│   └── Shared
│       └── _Layout.cshtml
│
├── wwwroot
│   ├── css
│   ├── js
│   └── images
│
├── Program.cs
├── appsettings.json
└── README.md
