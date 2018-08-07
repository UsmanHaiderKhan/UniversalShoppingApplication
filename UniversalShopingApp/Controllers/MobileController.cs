using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.GeneralProductManagement;
using UniversalShopingClasses.MobileManagement;

namespace UniversalShopingApp.Controllers
{
    public class MobileController : Controller
    {
        // GET: Mobile
        public ActionResult Index()
        {
            List<Mobile> mobiles = new MobileHandler().GetAllMobiles();
            return View(mobiles);
        }
        [HttpGet]
        public ActionResult CreateMobile()
        {
            DrinkHandler mHandler = new DrinkHandler();
            ViewBag.Brands = ModelHelper.ToSelectItemList(mHandler.GetAllBrands());
            return View();
        }
        [HttpPost]
        public ActionResult CreateMobile(Mobile mobile, FormCollection data)
        {
            UniversalContext db = new UniversalContext();
            mobile.ProductBrand = new ProductBrand { Id = Convert.ToInt32(data["brand"]) };
            mobile.Wifi = Convert.ToBoolean(data["wifi"].Split(',').First());
            mobile.BlueTooth = Convert.ToBoolean(data["bluetooth"].Split(',').First());
            mobile.ThreeG = Convert.ToBoolean(data["3g"].Split(',').First());
            mobile.FourG = Convert.ToBoolean(data["4g"].Split(',').First());
            long uno = DateTime.Now.Ticks;
            int counter = 0;
            foreach (string fcName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fcName];
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    string url = "/Content/ProductImages/" + uno + "_" + ++counter +
                                 file.FileName.Substring(file.FileName.LastIndexOf("."));
                    string path = Request.MapPath(url);
                    //m.Images = file.FileName;
                    file.SaveAs(path);
                    mobile.ProductImages.Add(new ProductImages() { Url = url, Perority = counter });
                }
            }
            using (db)
            {
                db.Mobiles.Add(mobile);
                db.Entry(mobile.ProductBrand).State = EntityState.Unchanged;

                db.SaveChanges();
                return RedirectToAction("Success", "drink");
            }

        }
    }
}
