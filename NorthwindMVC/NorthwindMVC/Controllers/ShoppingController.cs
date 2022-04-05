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
        private ShoppingCartBusiness shoppingCartList = new ShoppingCartBusiness();
        /*!
         * Lista de produtos
         */
        public ActionResult ShoppingIndex()
        {
            List<ShoppingCartExtend> list = shoppingCartList.SelectList();
            return View(list);
        }
        /*!
         * 
         */
        private List<SelectListItem> CreateCustomerList()
        {
            var custumers = new CustomersBusiness();
            var table = custumers.SelectList();
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Select...", Value = "0" });
            foreach (var item in table)
                list.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CustomerID });
            return list;
        }
        /*!
         * Cria novo produto 
         */
        public ActionResult ShoppingCreate()
        {            
            ViewBag.Customers = CreateCustomerList();
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
            if (shoppingCart.Description.Length > 100)
            {
                ModelState.AddModelError("Description", "Descrição deve ter no maximo 100 caracteres.");
            }
            if (ModelState.IsValid)
            {
                shoppingCartList.InsertItem(shoppingCart);
                return RedirectToAction("ShoppingIndex");
            }
            else
            {
                ViewBag.Customers = CreateCustomerList();
                return View("ShoppingCreate", shoppingCart);                
            }
        }

        public ActionResult ShoppingEdit(int id)
        {
            ViewBag.Customers = CreateCustomerList();
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
            shoppingCartList.DeleteItem(shoppingCart.ShoppingCartID);
            return RedirectToAction("ShoppingIndex");
        }

        



    }
}