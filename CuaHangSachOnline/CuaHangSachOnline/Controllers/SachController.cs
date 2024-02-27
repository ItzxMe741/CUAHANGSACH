using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Controllers
{
    public class SachController : Controller
    {
        CSDLDataContext db = new CSDLDataContext();
        // GET: Sach
        public ActionResult ThongTinSachMua(int id)
        {
            ChiTietSachBanResult ttsb = db.ChiTietSachBan(id).FirstOrDefault();
            return View(ttsb);
        }

        public ActionResult ThongTinSachThue(int id)
        {

            ChiTietSachThueResult ttst = db.ChiTietSachThue(id).FirstOrDefault();
            return View(ttst);
        }

    }
}