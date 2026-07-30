using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Demo credential store. Replace with a database-backed check (e.g. logintab table) for production use.
        private List<LoginModel> GetUsers()
        {
            return new List<LoginModel>
            {
                new LoginModel { id = 1, username = "admin", password = "12345", role = "Admin" },
                new LoginModel { id = 2, username = "mycodingproject", password = "myc546", role = "Student" },
                new LoginModel { id = 3, username = "my", password = "myc", role = "Librarian" },
            };
        }

        [HttpPost]
        public IActionResult Verify(LoginModel usr)
        {
            var users = GetUsers();
            var match = users.FirstOrDefault(u =>
                u.username == usr.username && u.password == usr.password);

            if (match != null)
            {
                TempData["message"] = $"Login Success for {match.role}";
                HttpContext.Session.SetString("Username", match.username ?? "");
                HttpContext.Session.SetString("Role", match.role ?? "");
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.message = "Login Failed. Please check your username and password.";
                return View("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["message"] = "You have been logged out.";
            return RedirectToAction("Index");
        }
    }
}
