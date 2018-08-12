using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public ActionResult AuctionByCategory(int id)
        {
            ViewBag.AuctionCat = AuctionHelper.AuctionSummeryList(new AuctionHandler().GetAuctionByCategory(id));
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
        [HttpGet]
        public ActionResult GetAuctionDetail()
        {
            List<Auction> auctions = new AuctionHandler().GetAllAuctions();
            return View(auctions);
        }
        [HttpGet]
        public ActionResult UpdateAuction(int id)
        {
            Auction auction = new AuctionHandler().GetAuctionById(id);
            return View(auction);
        }
        [HttpPost]
        public ActionResult UpdateAuction(Auction auction)
        {
            UniversalContext db = new UniversalContext();
            using (db)
            {
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetAuctionDetail", "Auction");
            }
        }
        public ActionResult DeleteAuction(int id)
        {
            UniversalContext db = new UniversalContext();
            Auction auction = (from c in db.Auctions
                    .Include(x => x.AuctionCategory)
                    .Include(m => m.ProductImages)
                               where c.Id == id
                               select c).FirstOrDefault();
            db.Entry(auction).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAuctionDetailForCustomer()
        {
            List<Auction> auctions = new AuctionHandler().GetAllAuctions();
            return View(auctions);
        }

    }
}
