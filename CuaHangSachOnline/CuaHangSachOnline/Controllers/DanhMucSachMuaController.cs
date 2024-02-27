using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Controllers
{
    public class DanhMucSachMuaController : Controller
    {
        // GET: DanhMucSachMua
        CSDLDataContext db = new CSDLDataContext();

        public ActionResult SachMua()
        {
            List<DanhSachSachBanResult> lstsachban = db.DanhSachSachBan().ToList();
            return View(lstsachban);
        }
    }
}