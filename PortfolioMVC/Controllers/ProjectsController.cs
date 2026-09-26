using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.Data;
using PortfolioMVC.Models;

namespace PortfolioMVC.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly List<Project> projects = new()
    {
        new Project
        {
            Id = 1,
            Title = "Personality Test",
            Description = "An interactive personality test application that allows users to answer questions and discover their personality type.",
            GitHubUrl = "https://github.com/VaughnMatt/PersonalityTest",
            Technologies = "C#, ASP.NET Core MVC, HTML, CSS",
            LongDescription =
                "The Personality Test is an interactive application that evaluates " +
                "a user's answers to a series of questions and provides a personality result."
        },

        new Project
        {
            Id = 2,
            Title = "Hackathon - Personality Test",
            Description = "A personality test application developed as part of a hackathon project.",
            GitHubUrl = "https://github.com/dominicbillena06-prog/Hackthon---Personality-test",
            Technologies = "C#, ASP.NET Core MVC, HTML, CSS",
            LongDescription =
                "This project was created as part of a hackathon and focuses on " +
                "providing users with an interactive personality testing experience."
        },

        new Project
        {
            Id = 3,
            Title = "H1, H2, H3",
            Description = "A collection of activities and exercises completed for the IT Elective 2 midterm assessment.",
            GitHubUrl = "https://github.com/VaughnMatt/IT_ELECTIVE_2_MIDTERM_H1_H2_H3_Mendoza",
            Technologies = "C#, ASP.NET Core MVC, HTML, CSS",
            LongDescription =
                "This project contains the H1, H2, and H3 activities completed " +
                "for the IT Elective 2 midterm requirements."
        },

        new Project
        {
            Id = 4,
            Title = "Prelim Exam",
            Description = "A web development project created for the IT Elective 2 preliminary examination.",
            GitHubUrl = "https://github.com/VaughnMatt/IT_ELECTIVE_2_PRELIM_EXAM_VAUGHNN_MENDOZA",
            Technologies = "C#, ASP.NET Core MVC, HTML, CSS",
            LongDescription =
                "This project was developed as part of the IT Elective 2 " +
                "preliminary examination and demonstrates the concepts covered in the course."
        }
    };

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Check if the user is logged in
        private bool IsLoggedIn()
        {
            return HttpContext.Session.GetString("IsLoggedIn") == "true";
        }

        // Display all projects
        public IActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            return View(projects);
        }

        // Display project details and comments
        public IActionResult Details(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var project = projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            // Get comments belonging to this project
            var comments = _context.Comments
                .Where(c => c.ProjectId == id)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            // Send comments to the Details view
            ViewBag.Comments = comments;

            return View(project);
        }

        // Add a comment to a project
        [HttpPost]
        public IActionResult AddComment(
            int projectId,
            string name,
            string message)
        {
            // Make sure the user is logged in
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            // Make sure the project exists
            var project = projects.FirstOrDefault(p => p.Id == projectId);

            if (project == null)
            {
                return NotFound();
            }

            // Don't allow empty comments
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(message))
            {
                return RedirectToAction(
                    "Details",
                    new { id = projectId });
            }

            // Create the comment
            var comment = new Comment
            {
                ProjectId = projectId,
                Name = name.Trim(),
                Message = message.Trim(),
                CreatedAt = DateTime.Now
            };

            // Save the comment to the database
            _context.Comments.Add(comment);
            _context.SaveChanges();

            // Return to the project details page
            return RedirectToAction(
                "Details",
                new { id = projectId });
        }
    }


}