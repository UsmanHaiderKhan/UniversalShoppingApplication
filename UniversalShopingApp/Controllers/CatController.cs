using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses.OLXClass;

namespace UniversalShopingApp.Controllers
{
    public class CatController : Controller
    {
        // GET: Cat
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult all()
        {
            DDListView model = new DDListView();
            model.Name = "Category";
            model.Caption = "- Select Category -";
            model.GlyphIcon = "fa-tag";
            model.Values = new AdvertisemntHandler().GetCategories().ToSelectItemList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", model);
        }

        [HttpGet]
        public ActionResult sub(int id)
        {
            DDListView model = new DDListView();
            model.Name = "SubCategory";
            model.Caption = "- Select Sub Category -";
            model.GlyphIcon = "fa-tag";
            model.Values = new AdvertisemntHandler().GetSubCategories(new AdvertismentCateory { Id = id }).ToSelectItemList();
            return PartialView("~/Views/Shared/_DDLView.cshtml", model);
        }
    }
}
