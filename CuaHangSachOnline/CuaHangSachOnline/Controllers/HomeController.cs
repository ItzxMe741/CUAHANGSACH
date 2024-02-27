using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangSachOnline.Models;

namespace CuaHangSachOnline.Controllers
{
    public class HomeController : Controller
    {

        CSDLDataContext db = new CSDLDataContext();

        public ActionResult Index()
        {
            
            HomeModel objhomeModel = new HomeModel();
            objhomeModel.lstLoaiSach = db.LoaiSaches.ToList();
            objhomeModel.lstSach = db.Saches.ToList();
            return View(objhomeModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            var dsLoaiSach = db.LoaiSaches.ToList();
            ViewBag.dsls = dsLoaiSach;
            return PartialView("_MenuHeader");
        }



    }
}