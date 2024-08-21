using LawyersFirm.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawyersFirm.Controllers
{
    public class CareerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CareerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var jobList = _context.Job.ToList();
            return View(jobList);
        }
    }
}
