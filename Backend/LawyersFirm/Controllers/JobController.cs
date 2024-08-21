using LawyersFirm.Data;
using LawyersFirm.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawyersFirm.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Check if user logged in
            var adminSession = HttpContext.Session.GetString("Username");
            if (adminSession == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var jobList = _context.Job.ToList();
            return View(jobList);
        }

        //CREATE: JOBS
        [HttpGet]
        public IActionResult Create()
        {
            //Check if user logged in
            var adminSession = HttpContext.Session.GetString("Username");
            if (adminSession == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var newJob = new Job();
            return View(newJob);
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                var existPosition = _context.Job.FirstOrDefault(j => j.Position == job.Position && j.Category == job.Category);
                if (existPosition != null)
                {
                    ModelState.AddModelError("Position", "Job for the same position already posted");
                    return View(existPosition);
                }

                _context.Job.Add(job);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(job);
        }

        //UPDATE: JOBs
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Check if user logged in
            var adminSession = HttpContext.Session.GetString("Username");
            if (adminSession == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var job = _context.Job.Find(id);

            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        [HttpPost]
        public IActionResult Edit(int id, Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Update(job);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(job);
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Check if user logged in
            var adminSession = HttpContext.Session.GetString("Username");
            if (adminSession == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var existJob = _context.Job.Find(id);

            if (existJob == null)
            {
                return NotFound();
            }

            return View(existJob);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var existJob = _context.Job.Find(id);

            if (existJob != null)
            {
                _context.Job.Remove(existJob);
                _context.SaveChanges();
            }
            return RedirectToAction(("Index"));
        }
    }
}
