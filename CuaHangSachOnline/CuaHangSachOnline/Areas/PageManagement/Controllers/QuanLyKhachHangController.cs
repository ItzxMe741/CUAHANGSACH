using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        CSDLDataContext db = new CSDLDataContext();

        public ActionResult QuanLyKhachHang()
        {
            List<AllKhachHangResult> lstkh = db.AllKhachHang().ToList();
            return View(lstkh);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(KhachHang kh)
        {

            db.AddKhachHang(kh.HoTen,kh.Email,kh.DiaChi,kh.Sdt,kh.Username,kh.Password);
            return RedirectToAction("QuanLyKhachHang");
        }

        public ActionResult Delete(int id)
        {
            KhachHang kh = db.KhachHangs.FirstOrDefault(x => x.IDKhach == id);
            if (kh != null)
            {
                db.DeleteKH(kh.IDKhach);
            }
            return RedirectToAction("QuanLyKhachHang");
        }

        //public ActionResult Edit(int id)
        //{
        //    var data = db.NhanViens.FirstOrDefault(x => x.IDNhanVien == id);
        //    return View(data);
        //}

        public ActionResult Edit(int id)
        {
            GetKHforIDResult kh = db.GetKHforID(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string HoTen = Request.Form["HoTen"];
                string Email = Request.Form["Email"];
                string Sdt = Request.Form["Sdt"];
                string DiaChi = Request.Form["DiaChi"];
                db.EditKhachHang(kh.IDKhach, HoTen, Email, Sdt, DiaChi);
                db.SubmitChanges();
                TempData["AlertMessage"] = " Cập nhật thành công";
                return RedirectToAction("QuanLyKhachHang");
            }

            return View(kh);
        }

        public ActionResult EditTkKhachHang(int id)
        {
            GetKHforIDResult kh = db.GetKHforID(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string UserName = Request.Form["UserName"];
                string Password = Request.Form["Password"];
                db.EditTkKhachHang(kh.IDKhach, UserName, Password);
                db.SubmitChanges();
                TempData["AlertMessage"] = " Cập nhật thành công";
                return RedirectToAction("QuanLyKhachHang");
            }

            return View(kh);
        }
    }
}