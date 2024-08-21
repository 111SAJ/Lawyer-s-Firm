using LawyersFirm.Data;
using Microsoft.AspNetCore.Mvc;

namespace LawyersFirm.Controllers
{
    public class EmailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchQuery = "", int page = 1, int pageSize = 5)
        {
            //Check if user logged in
            var adminSession = HttpContext.Session.GetString("Username");
            if (adminSession == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var contactsQuery = _context.Contact.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                contactsQuery = contactsQuery.Where(c => c.Name.Contains(searchQuery)
                                                       || c.Email.Contains(searchQuery)
                                                       || c.Phone.Contains(searchQuery));
            }

            var totalCount = contactsQuery.Count();
            var emailList = contactsQuery
                            .OrderByDescending(c => c.CreatedOn)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = totalCount;
            ViewBag.SearchQuery = searchQuery;

            return View(emailList);
        }

    }
}
