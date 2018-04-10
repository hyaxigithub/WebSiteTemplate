using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYWeb.Areas.WeiXin.Controllers
{
    public class CatalogController : Controller
    {
        // GET: WeiXin/Catalog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeatSelect()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SeatSelect(FormCollection collection)
        {
            return Json(new {resCode=0,message="返回数据成功",data=new {customer_seat="6排10座",price="180.00" } });
        }

        [HttpPost]
        public JsonResult SeatConfirm(FormCollection collection)
        {
            return Json(new { resCode = 0, message = "返回数据成功",data=new {Id=369 } });
        }
        public ActionResult SeatInfo()
        {
            return View();
        }
    }
}