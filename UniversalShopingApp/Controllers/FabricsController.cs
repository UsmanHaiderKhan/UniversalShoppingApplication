using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversalShopingApp.Models;
using UniversalShopingClasses;
using UniversalShopingClasses.DrinksManagement;
using UniversalShopingClasses.FabricsManagement;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingApp.Controllers
{
    public class FabricsController : Controller
    {
        // GET: Fabrics
        public ActionResult Index()
        {
            List<Fabric> fabrics = new FabricHandler().GetAllProducts();
            return View(fabrics);
        }

        [HttpGet]
        public ActionResult AddFabrics()
        {
            DrinkHandler mHandler = new DrinkHandler();
            ViewBag.Brands = ModelHelper.ToSelectItemList(mHandler.GetAllBrands());
            return View();
        }

        [HttpPost]
        public ActionResult AddFabrics(Fabric fabric, FormCollection data)
        {
            fabric.ProductBrand = new ProductBrand { Id = Convert.ToInt32(data["brand"]) };
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
                    fabric.ProductImages.Add(new ProductImages() { Url = url, Perority = counter });
                }
            }

            UniversalContext db = new UniversalContext();
            using (db)
            {
                db.Fabrics.Add(fabric);
                db.Entry(fabric.ProductBrand).State = EntityState.Unchanged;
                db.SaveChanges();
                return RedirectToAction("Complete", "Drink");
            }
        }

        public ActionResult DeleteFabrics(int id)
        {
            UniversalContext db = new UniversalContext();
            Fabric fabric = (from c in db.Fabrics
                    .Include(x => x.ProductBrand)
                    .Include(m => m.ProductImages)
                             where c.Id == id
                             select c).FirstOrDefault();
            db.Entry(fabric).State = EntityState.Deleted;
            db.SaveChanges();
            return Json("Delete", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UpdateFabric(int id)
        {
            Fabric fabric = new FabricHandler().GetFabricById(id);
            return View(fabric);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult UpdateFabric(Fabric fabric)
        {
            UniversalContext db = new UniversalContext();
            if (ModelState.IsValid)
            {
                using (db)
                {
                    db.Entry(fabric).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Fabrics");
        }

    }
}
