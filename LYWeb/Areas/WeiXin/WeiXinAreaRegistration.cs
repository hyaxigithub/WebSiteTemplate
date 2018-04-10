using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LYWeb.Areas.WeiXin
{
    public class WeiXinAreaRegistration:AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WeiXin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(name: "weixin.default", url: "weixin/{controller}/{action}/{id}",
               defaults: new { controller = "weixin", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "LYWeb.Areas.WeiXin.Controllers" }
                );
        }

    }
}