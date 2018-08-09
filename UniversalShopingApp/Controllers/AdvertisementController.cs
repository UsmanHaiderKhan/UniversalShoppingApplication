using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses;
using UniversalShopingClasses.GeneralProductManagement;
using UniversalShopingClasses.OLXClass;

namespace UniversalShopingApp.Controllers
{
    public class AdvertisementController : Controller
    {
        // GET: Advertisement
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.NewAdvs = new AdvertisemntHandler().GetLatestAdvertisements(12).ToAdvSumModelList();
            return View();
        }

        [HttpGet]
        public ActionResult PostAdvertisement()
        {
            ViewBag.Categories = new AdvertisemntHandler().GetCategories().ToSelectItemList();
            List<SelectListItem> tempList = new AdvertisemntHandler().GetTypes().ToSelectItemList();
            tempList.First().Selected = true;
            ViewBag.AdvTypes = tempList;
            return View();
        }

        [HttpPost]
        public ActionResult PostAdvertisement(Advertisement advertisement, FormCollection data)
        {
            try
            {
                advertisement.SubCategory = new AdvertisementSubCategory { Id = Convert.ToInt32(data["SubCategory"]) };
                advertisement.Type = new AdvertisementType { Id = Convert.ToInt32(data["AdvType"]) };
                advertisement.PostedOn = DateTime.Now;
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
                        advertisement.Images.Add(new ProductImages() { Url = url, Perority = counter });
                    }
                }
                UniversalContext db = new UniversalContext();
                using (db)
                {
                    db.Advertisements.Add(advertisement);
                    db.Entry(advertisement.Type).State = EntityState.Unchanged;
                    db.Entry(advertisement.SubCategory).State = EntityState.Unchanged;
                    db.SaveChanges();
                    TempData.Add("Message",
                        new AlertMessage("Advertisement added successfully", AlertMessageType.Success));
                }
            }
            catch (Exception ex)
            {
                TempData.Add("Message",
                    new AlertMessage("Failed to add advertisements, try later", AlertMessageType.Error));
                throw ex;
            }

            return View();

        }

        [HttpGet]
        public ActionResult ByCategory(int id)
        {
            ViewBag.Advertisements = new AdvertisemntHandler().GetAdvertisementsByCategory(new AdvertismentCateory() { Id = id }).ToAdvSumModelList();
            return View();
        }
        [HttpGet]
        public ActionResult ViewDetailofPost(int id)
        {
            List<Advertisement> advertisements = new AdvertisemntHandler().GetAllAdvertisementById(id);
            return View(advertisements);
        }

        public ActionResult AdminAdvDetails()
        {
            List<Advertisement> advertisements = new AdvertisemntHandler().GetAllAdvertisement();
            return View(advertisements);
        }

    }
}
