using LawyersFirm.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawyersFirm.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var adminSession = HttpContext.Session.GetString("Username");
            if (adminSession == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
