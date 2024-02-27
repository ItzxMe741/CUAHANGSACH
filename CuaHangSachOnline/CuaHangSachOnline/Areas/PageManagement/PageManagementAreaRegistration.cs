﻿using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement
{
    public class PageManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PageManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PageManagement_default",
                "PageManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "CuaHangSachOnline.Areas.PageManagement.Controllers" }
            );
        }
    }
}