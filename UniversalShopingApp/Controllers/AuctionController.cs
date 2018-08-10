using System;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses;
using UniversalShopingClasses.AuctionManagement;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingApp.Controllers
{
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            ViewBag.NewProduct = new AuctionHandler().GetLatestAuction(12).ToAuctinoSummeryModelList();
            return View();
        }
        [HttpGet]
        public ActionResult AddAuctinoProduct()
        {
            AuctionHandler mHandler = new AuctionHandler();
            ViewBag.Brands = AuctionHelper.ToSelectItemList(mHandler.GetCategories());
            return View();
        }

        [HttpPost]
        public ActionResult AddAuctinoProduct(Auction auction, FormCollection data)
        {
            try
            {
                UniversalContext db = new UniversalContext();
                auction.AuctionCategory = new AuctionCategory { Id = Convert.ToInt32(data["AuctionCategory"]) };
                auction.Postedon = DateTime.Now;
                long uno = DateTime.Now.Ticks;
                int counter = 0;
                foreach (string fcName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fcName];
                    if (!string.IsNullOrWhiteSpace(file.FileName))
                    {
                        string ext = file.FileName.Substring(file.FileName.LastIndexOf("."));
                        string url = "/Content/ProductImages/" + $"{uno}_{++counter}{ext}";
                        string path = Request.MapPath(url);
                        file.SaveAs(path);
                        auction.ProductImages.Add(new ProductImages() { Url = url, Perority = counter });
                    }
                }

                using (db)
                {
                    db.Auctions.Add(auction);
                    db.Entry(auction.AuctionCategory).State = EntityState.Unchanged;
                    db.SaveChanges();
                    TempData.Add("Message",
                        new AlertMessage("Advertisement added successfully", AlertMessageType.Success));
                }
            }
            catch (Exception e)
            {
                TempData.Add("Message",
                    new AlertMessage("Failed to add advertisements, try later", AlertMessageType.Error));
                Console.WriteLine(e);
                throw;
            }


            return RedirectToAction("AddAuctinoProduct");
        }
    }
}
