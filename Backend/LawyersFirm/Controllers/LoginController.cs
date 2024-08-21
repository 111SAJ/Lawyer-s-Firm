using LawyersFirm.Data;
using LawyersFirm.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawyersFirm.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Login Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Login login)
        {
            var loggedIn = _context.Admin.FirstOrDefault(e => e.Username == login.Username && e.Password == login.Password);
            if (loggedIn != null)
            {
                login.isLoggedIn = true;
                HttpContext.Session.SetString("Username", login.Username);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
