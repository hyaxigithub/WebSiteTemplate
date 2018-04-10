using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYWeb.Areas.WeiXin.Controllers
{
    public class OrderController : Controller
    {
        // GET: WeiXin/Order
        public ActionResult OrderSelect()
        {
            return View();
        }

        public ActionResult OrderSelByPhone()
        {
            return View();
        }
    }
}