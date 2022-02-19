using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVC.Controllers
{
    public class DataTableController : Controller
    {
        // GET: DataTable
        public ActionResult ProductsTable()
        {
            var products = new ProductsBusiness();
            var table = products.SelectList();
            return View(table);
        }
    }
}