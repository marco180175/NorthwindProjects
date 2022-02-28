using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult IndexCategories()
        {
            var categories = new CategoriesBusiness();
            var table = categories.SelectList();
            return View(table);
        }


    }
}