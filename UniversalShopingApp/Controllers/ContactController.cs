using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public ActionResult DeleteContact(int id)
        {
            UniversalContext db = new UniversalContext();
            Contact contact = (from c in db.Contacts
                               where c.Id == id
                               select c).FirstOrDefault();
            db.Entry(contact).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }


    }
}
