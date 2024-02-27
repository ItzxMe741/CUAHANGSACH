using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Controllers
{
    public class DanhMucSachThueController : Controller
    {
        // GET: SachThue
        CSDLDataContext db = new CSDLDataContext();
        public ActionResult SachThue()
        {
            List<DanhSachSachThueResult> lstsachthue = db.DanhSachSachThue().ToList();
            return View(lstsachthue);
        }
    }
}