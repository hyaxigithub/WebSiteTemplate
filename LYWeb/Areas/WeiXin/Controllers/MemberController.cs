using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYWeb.Areas.WeiXin.Controllers
{
    public class MemberController : Controller
    {
        // GET: WeiXin/Member
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginByUser()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}