using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class QuanLyLoaiSachController : Controller
    {
        CSDLDataContext db = new CSDLDataContext();
            public ActionResult QuanLyLoaiSach()
        {
            List<LoaiSach> lstloaisach = db.LoaiSaches.ToList();
            return View(lstloaisach);
        }

        public ActionResult ThemLoaiSach()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemLoaiSach(LoaiSach loaisach)
        {


            if (Request.Form.Count > 0)
            {

                LoaiSach ls = new LoaiSach();
                ls.TenLoaiSach = Request.Form["TenLoaiSach"];
                ls.TrangThai = Request.Form["TrangThai"];
                HttpPostedFileBase file = Request.Files["Imagels"];
                if (file != null)
                {
                    string svPath = HttpContext.Server.MapPath("~/Content/images");
                    string filePath = svPath + "/" + file.FileName;
                    file.SaveAs(filePath);
                    loaisach.Imagels = file.FileName;
                }

                db.LoaiSaches.InsertOnSubmit(loaisach);
                db.SubmitChanges();
                return RedirectToAction("QuanLyLoaiSach", "QuanLyLoaiSach", new { area = "PageManagement" });

            }
            return View();
        }



        public ActionResult Delete(int id)
        {
            LoaiSach ls = db.LoaiSaches.FirstOrDefault(x => x.IDLoaiSach == id);
            if (ls != null)
            {
                db.DeleteLoaiSach(ls.IDLoaiSach);
            }
            return RedirectToAction("QuanLyLoaiSach");
        }

        public ActionResult SuaLoaiSach(int id)
        {
            LoaiSach ls = db.LoaiSaches.FirstOrDefault(x => x.IDLoaiSach == id);
            return View(ls);
        }

        [HttpPost]
        public ActionResult SuaLoaiSach(int id, LoaiSach lsach)
        {
            LoaiSach ls = db.LoaiSaches.FirstOrDefault(x => x.IDLoaiSach == id);
            if (ls != null)
            {
                ls.TenLoaiSach = lsach.TenLoaiSach;
                ls.TrangThai = lsach.TrangThai;
                HttpPostedFileBase file = Request.Files["Imagels"];
                if (file != null)
                {
                    string svPath = HttpContext.Server.MapPath("~/Content/images");
                    string filePath = svPath + "/" + file.FileName;
                    file.SaveAs(filePath);
                    ls.Imagels = file.FileName;
                }

                db.SubmitChanges();
            }
            return RedirectToAction("QuanLyLoaiSach");
        }

        //public ActionResult procDetail(int id)
        //{
        //    CSDLDataContext db = new CSDLDataContext();
        //    ChiTietSachResult sach = db.ChiTietSach(id).FirstOrDefault();
        //    return View(sach);
        //}

    }
}