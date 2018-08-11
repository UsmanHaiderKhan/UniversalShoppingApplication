using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UniversalShopingClasses;
using UniversalShopingClasses.GeneralProductManagement;

namespace UniversalShopingApp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            List<ProductType> productTypes = new ProductHandler().GetAllTypes();

            return View(productTypes);
        }
        [HttpGet]
        public ActionResult AddProductType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProductType(FormCollection data, ProductType productType)
        {
            UniversalContext db = new UniversalContext();
            if (ModelState.IsValid)
            {
                productType.Id = Convert.ToInt32(data["Id"]);
                productType.Name = data["Name"];
                db.ProductTypes.Add(productType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productType);
        }


        public ActionResult DeleteProductType(int id)
        {
            ProductType productType = new ProductHandler().GetProductTypeById(id);
            if (productType == null)
            {
                return HttpNotFound();
            }
            return View(productType);

        }
        [HttpPost, ActionName("DeleteProductType")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductTypeConfirmed(int id)
        {
            ProductType productType = new ProductHandler().GetProductTypeById(id);
            new ProductHandler().DeleteOperatingSystem(productType);
            return RedirectToAction("Index");

        }


        public ActionResult ProductCategories(int id)
        {
            ProductType productType = new ProductHandler().GetProductTypeById(id);
            List<ProductBrand> productBrands = new ProductHandler().GetProductBrandBypType(productType);
            ViewBag.OSId = id;
            ViewBag.OperatingSystem = productType.Name;
            return View(productBrands);
        }
        [HttpGet]
        public ActionResult AddProductBrands(int id)
        {
            ViewBag.OperatingSystem = new ProductHandler().GetProductTypeById(id).Name;
            return View();
        }
        [HttpPost]
        public ActionResult AddProductBrands(FormCollection data, int id)
        {
            ProductBrand c = new ProductBrand();
            c.Name = data["Name"];
            c.ProductType = new ProductHandler().GetProductTypeById(id);
            new ProductHandler().AddProductBrand(c);

            return RedirectToAction("ProductCategories", new { Id = id });
        }
        public ActionResult DeleteProductBrands(int? id, int osid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductBrand c = new ProductHandler().GetProductBrandById(osid);

            if (c == null)
            {
                return HttpNotFound();
            }
            ViewBag.OSId = osid;
            TempData["ProductType"] = osid;
            return View(c);
        }
        [HttpPost, ActionName("DeleteProductBrands")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProductBrandsConfirm(int id)
        {
            ProductBrand productBrand = new ProductHandler().GetProductBrandById(id);
            new ProductHandler().DeleteProductBrands(productBrand);

            return RedirectToAction("ProductCategories", new { Id = Convert.ToInt32(TempData["ProductType"]) });
        }
    }
}
