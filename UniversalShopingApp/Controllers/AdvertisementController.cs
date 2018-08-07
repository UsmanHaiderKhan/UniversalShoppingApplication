using System.Web.Mvc;

namespace UniversalShopingApp.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult PostAdvertisement()
        //{
        //    ViewBag.Categories - new AdvertisemntHandler().GetCategories().
        //    List<SelectListItem> tempList = new AdvertisemntHandler().GetTypes().ToSelectItemList();
        //    tempList.First().Selected = true;
        //    ViewBag.AdvTypes = tempList;
        //}

    }
}
