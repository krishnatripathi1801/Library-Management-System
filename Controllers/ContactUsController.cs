using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string name, string email, string message)
        {
            // In production, send an email or save to a database here.
            TempData["SuccessMessage"] = "Thanks for reaching out! We'll get back to you within 24 hours.";
            return RedirectToAction("Index");
        }
    }
}
