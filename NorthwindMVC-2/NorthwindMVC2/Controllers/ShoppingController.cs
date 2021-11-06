using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindMVC2.Controllers
{
    public class ShoppingController : Controller
    {
        private ShoppingCartList shoppingCartList = new ShoppingCartList();
        // GET: Shopping
        public ActionResult Index()
        {
            var list = shoppingCartList.Get();
            return View(list);
        }
    }
}