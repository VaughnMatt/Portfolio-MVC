using Microsoft.AspNetCore.Mvc;
using PortfolioMVC.Models;

namespace PortfolioMVC.Controllers
{
    public class AccountController : Controller
    {
        private const string Username = "admin";
        private const string Password = "Portfolio123!";

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Username == Username &&
                model.Password == Password)
            {
                HttpContext.Session.SetString("IsLoggedIn", "true");

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(
                "",
                "Invalid username or password.");

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
