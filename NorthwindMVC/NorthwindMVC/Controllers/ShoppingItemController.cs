using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class ShoppingItemController : Controller
    {
        private static int shoppingCartID;
        /*!
         * Mostra lista de items
         * @param id: identificador do carrinho de compras
         */
        public ActionResult ShoppingItemIndex(int id)
        {
            shoppingCartID = id;
            var shoppingCartBusiness = new ShoppingCartItemBusiness(shoppingCartID);
            var list = shoppingCartBusiness.SelectList();
            return View(list);
        }

        public ActionResult ShoppingItemCreate(int? id)
        {
            ViewBag.ShoppingCartID = shoppingCartID;            
            ShoppingCartItem item = new ShoppingCartItem();
            if (id.HasValue)
            {
                var products = new ProductsBusiness();
                var product = products.SelectItem(id.Value);
                //item.ProductID = product.ProductID;
                //item.UnitPrice = product.UnitPrice;
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShoppingItemCreateNew(ShoppingCartItem shoppingCartitem)
        {
            //validaçoes servidor
            var shoppingCart = new ShoppingCartItemBusiness(shoppingCartID);
            if (shoppingCartitem.ProductID == 0)
            {
                ModelState.AddModelError("ProductID", "Selecione id do produto...");
            }
            if (shoppingCartitem.UnitPrice == 0)
            {
                ModelState.AddModelError("UnitPrice", "Selecione preço unitario do produto...");
            }
            if (ModelState.IsValid)
            {
                shoppingCart.InsertItem(shoppingCartitem);
                return RedirectToAction("ShoppingItemIndex", new { id = shoppingCartID });
            }
            else
            {
                return View("ShoppingItemCreate", shoppingCartitem);
            }
        }

        public ActionResult ShoppingItemProductList(int id1, int id2, int id3)
        {
            ViewBag.SourceID = id2;
            ViewBag.ShoppingCartItemID = id3; 
            var products = new ProductsBusiness();
            List<Product> list =new List<Product>();
            
            //if (id1 == 0)
            //    list = products.SelectList();
            //else
            //    list = products.SelectListByCategory(id1);
            return View(list);
        }

        public ActionResult ShoppingItemEdit(int id1, int id2)
        {
            ViewBag.ShoppingCartID = shoppingCartID;
                       
            var shoppingCart = new ShoppingCartItemBusiness(shoppingCartID);
            //ShoppingCartItem item = shoppingCart.SelectItem(id1);
            //if (id2 != 0)
            //{
            //    var products = new ProductsBusiness();
            //    var product = products.SelectItem(id2);
            //    //item.ProductID = product.ProductID;
            //    //item.UnitPrice = product.UnitPrice;
            //}
            //return View(item);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShoppingItemEdit(ShoppingCartItem shoppingCartitem)
        {
            var shoppingCart = new ShoppingCartItemBusiness(shoppingCartID);
            shoppingCart.InsertItem(shoppingCartitem);
            return RedirectToAction("ShoppingItemIndex", new { id = shoppingCartID });
        }
    }
}