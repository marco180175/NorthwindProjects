using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindTelerikMVC.Controllers
{
    public class HomeController : Controller
    {
        private ShoppingCartBusiness shoppingCartBusiness = new ShoppingCartBusiness();
        // GET: Home
        public ActionResult Index()
        {
            var list = shoppingCartBusiness.SelectList();
            return View(list);
        }
    }
}