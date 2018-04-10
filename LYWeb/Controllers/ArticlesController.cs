using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYWeb.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult NewsList()
        {
            return View();
        }

        public ActionResult NewsEdit()
        {
            return View();
        }

        public ActionResult NewsEdit2()
        {
            return View();
        }
    }
}