using System.Web.Mvc;
using UniversalShopingClasses.AuctionManagement;

namespace UniversalShopingApp.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAuctinoProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuctinoProduct(Auction auction)
        {
            return View();
        }
    }
}
