using LawyersFirm.Data;
using LawyersFirm.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LawyersFirm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var newContact = new Contact();
            return View(newContact);
        }

        //POST: Contact Form
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contact.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public IActionResult SayedAsadJamal()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
