using Microsoft.AspNetCore.Mvc;

namespace LawyersFirm.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
