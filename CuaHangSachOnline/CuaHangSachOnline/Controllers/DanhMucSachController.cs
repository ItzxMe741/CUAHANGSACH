using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Controllers
{
    public class DanhMucSachController : Controller
    {
        CSDLDataContext db = new CSDLDataContext();
        // GET: DanhMucSach
        public ActionResult Index()
        {
            List<LoaiSach> lstLoaiSach = db.LoaiSaches.ToList();
            return View(lstLoaiSach);
        }

        public ActionResult DanhSachtheoLoaiSach(int id)
        {
            List<DanhSachtheoLoaiSachResult> lstSachtheoLoaiSach = db.DanhSachtheoLoaiSach(id).ToList();
            return View(lstSachtheoLoaiSach);
        }
    }
}