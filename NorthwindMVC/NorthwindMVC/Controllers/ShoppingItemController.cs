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

        private void SetupView()
        {
            ViewBag.ShoppingCartID = shoppingCartID;
            var list1 = CreateCategoryList();
            list1[indexCategory].Selected = true;
            ViewBag.Categories = list1;
            ViewBag.Products = CreateProductList(indexCategory);
        }

        public ActionResult ShoppingItemCreate()
        {
            SetupView();
            var item = new ShoppingCartItem();            
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShoppingItemCreate(ShoppingCartItem shoppingCartitem)
        {
            //validaçoes servidor
            var shoppingCartItemBusiness = new ShoppingCartItemBusiness(shoppingCartID);
            if (shoppingCartitem.ProductID == 0)
            {
                ModelState.AddModelError("ProductID", "Selecione um produto.");
            }
            if (shoppingCartitem.Quantity == 0)
            {                
                ModelState.AddModelError("Quantity", "Especifique a quantidade.");
            }
            if (ModelState.IsValid)
            {
                var productBusiness = new ProductsBusiness();
                var product = productBusiness.SelectItem(shoppingCartitem.ProductID);
                shoppingCartitem.UnitPrice = product.UnitPrice;
                shoppingCartitem.ShoppingCartID = shoppingCartID;
                shoppingCartItemBusiness.InsertItem(shoppingCartitem);
                return RedirectToAction("ShoppingItemIndex", new { id = shoppingCartID });
            }
            else
            {
                SetupView();
                return View("ShoppingItemCreate", shoppingCartitem);
            }
        }

        public ActionResult ShoppingItemEdit(int id1, int id2)
        {
            //ShoppingCartItem item = new ShoppingCartItem();
            //if (id.HasValue)
            //{
            //    var products = new ProductsBusiness();
            //    var product = products.SelectItem(id.Value);
            //    //item.ProductID = product.ProductID;
            //    //item.UnitPrice = product.UnitPrice;
            //}
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
        
        private static int indexCategory = 0;

        public ActionResult ShoppingItemSetProductID(int id)
        {
            indexCategory = id;            
            return RedirectToAction("ShoppingItemCreate");            
        }

        [HttpGet]
        public JsonResult ShoppingItemSetProductIdJson(int id)
        {
            indexCategory = id;            
            var list = CreateProductList(indexCategory);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        private List<SelectListItem> CreateCategoryList()
        {
            var category = new CategoriesBusiness();
            var table = category.SelectList();
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "All", Value = "0" });
            foreach (var item in table)
                list.Add(new SelectListItem() { Text = item.CategoryName, Value = item.CategoryID.ToString() });
            return list;
        }

        public List<SelectListItem> CreateProductList(int id)
        {
            var products = new ProductsBusiness();
            List<Product> list1 = new List<Product>();
            if (id == 0)
                list1 = products.SelectList();
            else
                list1 = products.SelectListByCategory(id);
            var list2 = new List<SelectListItem>();
            list2.Add(new SelectListItem() { Text = "Select", Value = "0" });
            foreach (var item in list1)
                list2.Add(new SelectListItem() { Text = item.ProductID.ToString("000") +"-"+ item.ProductName + "[" + item.UnitPrice + "]", Value = item.ProductID.ToString() });
            return list2;
        }

        [HttpGet]
        public JsonResult GetProductInfo(int id)
        {
            var products = new ProductsBusiness();
            var list = products.SelectListInfo(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}