using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class ProductsController : Controller
    {
        //private List<ProductQuery> table;
        
        public ActionResult FilterProducts()
        {
            var filters = new List<SelectListItem>();
            filters.Add(new SelectListItem() { Text = "None", Value = "0" });
            filters.Add(new SelectListItem() { Text = "Supplier", Value = "1" });
            filters.Add(new SelectListItem() { Text = "Category", Value = "2" });
            filters.Add(new SelectListItem() { Text = "Discontinued", Value = "3" });
            //
            var suppliers = new SuppliersBusiness();
            var supplier = new List<SelectListItem>();
            var list1 = suppliers.SelectList();
            foreach (var item in list1)
                supplier.Add(new SelectListItem() { Value = item.SupplierID.ToString(), Text = item.CompanyName });
            //
            var categories = new CategoriesBusiness();
            var category = new List<SelectListItem>();
            var list2 = categories.SelectList();
            //

            ViewBag.Filters = filters;
            ViewBag.SupplierList = supplier;
            ViewBag.CategoryList = category;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterProducts(FilterProducts result)
        {            
            return RedirectToAction("IndexProducts", new { filter = result.ToString() });
        }
        // GET: Products
        public ActionResult IndexProducts(string filter)
        {
            var products = new ProductsBusiness();
            var table = products.SelectListQuery(filter);
            return View(table);           
        }
        /*!
         * View Create
         */
        public ActionResult CreateProduct()
        {
            return View();
        }
        /*!
         * Processa retorno na view Create
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(Product product)
        {
            
            return RedirectToAction("IndexProducts");
        }
        /*!
         * View Edit
         */
        public ActionResult EditProduct(int id)
        {
            var products = new ProductsBusiness();
            Product product = products.SelectItem(id);
            return View(product);
        }
        /*!
         * Processa retorno na view Edit
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(Product product)
        {

            return RedirectToAction("IndexProducts");
        }
    }
}