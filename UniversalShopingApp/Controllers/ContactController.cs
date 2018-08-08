using System.Collections.Generic;
using System.Web.Mvc;
using UniversalShopingClasses;
using UniversalShopingClasses.UserManagement;

namespace UniversalShopingApp.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            List<Contact> contact = new UserHandler().GetAllMessages();
            return View(contact);
        }
        [HttpGet]
        public ActionResult SubmitMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitMessage(Contact contact)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("SuccessMessage", "Contact");
            }
        }

        public ActionResult SuccessMessage()
        {
            return View();
        }

        public ActionResult FirstPage()
        {
            return View();
        }


    }
}
