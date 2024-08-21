using LawyersFirm.Data;
using LawyersFirm.Models;
using Microsoft.AspNetCore.Mvc;

namespace LawyersFirm.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
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
    }
}
