using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class ShoppingController : Controller
    {
        private ShoppingCartListBusiness shoppingCartList = new ShoppingCartListBusiness();
        /*!
         * Lista de produtos
         */
        public ActionResult ShoppingIndex()
        {
            var list = shoppingCartList.SelectList();
            return View(list);
        }
        /*!
         * Cria novo produto 
         */
        public ActionResult ShoppingCreate()
        {
            var custumers = new CustomersBusiness();
            var table = custumers.SelectList();
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Select...", Value = "0" });
            foreach (var item in table)            
                list.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CustomerID });
            ViewBag.Customers = list;
            //
            var shoppingCart = new ShoppingCart();
            return View(shoppingCart);
        }
        /*!
         * Valida e adiciona novo produto na lista 
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShoppingCreate(ShoppingCart shoppingCart)
        {
            //validacoes
            if (shoppingCart.CustomerID == "0")
            {
                ModelState.AddModelError("CustomerID", "Selecione opção a customer.");
            }            
            //if (!string.IsNullOrEmpty(shoppingCart.Description) && shoppingCart.Description.Length > 100)
            //{
            //    ModelState.AddModelError("Description", "Descrição deve ter no maximo 100 caracteres.");
            //}
            if (ModelState.IsValid)
            {
                shoppingCartList.InsertItem(shoppingCart);
                return RedirectToAction("ShoppingIndex");
            }
            else
            {
                return View("ShoppingCreate", shoppingCart);                
            }
        }

        public ActionResult ShoppingEdit(int id)
        {
            var item = shoppingCartList.SelectItem(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShoppingEdit(ShoppingCart shoppingCart)
        {
            //validacoes
            if (shoppingCart.CustomerID == "0")
            {
                ModelState.AddModelError("CustomerID", "Selecione opção a customer.");
            }
            if (ModelState.IsValid)
            {
                shoppingCartList.UpdateItem(shoppingCart);
                return RedirectToAction("ShoppingIndex");
            }
            else
            {
                return View("ShoppingEdit", shoppingCart);
            }
        }

        public ActionResult ShoppingDelete(int id)
        {
            var item = shoppingCartList.SelectItem(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShoppingDelete(ShoppingCart shoppingCart)
        {
            //shoppingCartList.Delete(shoppingCart.ShoppingCartID);
            return RedirectToAction("ShoppingIndex");
        }
        
        

        
    }
}