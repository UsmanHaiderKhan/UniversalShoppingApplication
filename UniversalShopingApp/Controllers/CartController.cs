using System;
using System.Web.Mvc;
using UniversalShopingApp.Models;

namespace UniversalShopingApp.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        [HttpGet]

        public int Add(ShoppingCartItem item)
        {
            ShoppingCart cart = (ShoppingCart)Session[WebUtils.Cart];
            if (cart == null) cart = new ShoppingCart();
            cart.Add(item);
            Session.Add(WebUtils.Cart, cart);
            return cart.NumberOfItems;
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session[WebUtils.Cart];
            if (cart != null)
            {
                cart.Remove(id);
                Session.Add(WebUtils.Cart, cart);
            }
            return RedirectToAction("ViewCart");
        }

        public int Update()
        {
            ShoppingCart cart = (ShoppingCart)Session[WebUtils.Cart];
            if (cart != null)
            {
                cart.Update(Convert.ToInt32(Request.QueryString["id"]), Convert.ToInt32(Request.QueryString["qty"]));
                Session.Add(WebUtils.Cart, cart);
            }
            return cart.NumberOfItems;
        }

        [HttpGet]
        public ActionResult ViewCart()
        {
            ShoppingCart cart = (ShoppingCart)Session[WebUtils.Cart];
            if (cart == null)
            {
                return RedirectToAction("Empty", "Cart");
            }
            if (cart != null)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                ViewBag.GrandTotal = cart.GrandTotal;
            }
            else
            {
                return RedirectToAction("Empty", "Cart");
            }
            return View();
        }


        public int ItemsCount()
        {
            ShoppingCart cart = (ShoppingCart)Session[WebUtils.Cart];
            return (cart == null) ? 0 : cart.NumberOfItems;
        }

        public ActionResult Empty()
        {
            return View();
        }


    }
}
