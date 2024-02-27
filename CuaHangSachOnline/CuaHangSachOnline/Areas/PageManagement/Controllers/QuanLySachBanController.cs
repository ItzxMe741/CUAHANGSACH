using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class QuanLySachBanController : Controller
    {
        // GET: PageManagement/QuanLySachBanT
        CSDLDataContext db = new CSDLDataContext();
        // GET: PageManagement/QuanLySach
        public ActionResult QuanLySachBan()
        {
            List<DanhSachSachBanResult> lstsachban = db.DanhSachSachBan().ToList();
            return View(lstsachban);
        }

        public ActionResult ThemSachBan()
        {
            TempData["AllLoaiSach"] = db.AllLoaiSach().ToList();
            TempData["AllNXB"] = db.AllNXB().ToList();
            TempData["AllNgonNgu"] = db.AllNgonNgu().ToList();
            TempData["AllTacGia"] = db.AllTacGia().ToList();
            TempData["AllViTri"] = db.AllViTri().ToList();
            return View();
        }


        [HttpPost]
        public ActionResult ThemSachBan(Sach sach)
        {


            if (Request.Form.Count > 0)
            {

                Sach s = new Sach();
                s.MaSach = Request.Form["MaSach"];
                s.TenSach = Request.Form["TenSach"];
                sach.LoaiSachXem = "buy";
                s.NamXB = Convert.ToInt32(Request.Form["NamXB"]);
                s.TaiBan = Request.Form["TaiBan"];
                s.GiaBan = Convert.ToInt32(Request.Form["GiaBan"]);
                s.Metakeyword = Request.Form["Metakeyword"];
                s.MetaDescription = Request.Form["MetaDescription"];
                s.TrangThai = Request.Form["TrangThai"];
                s.LoaiSachIDLoaiSach = Convert.ToInt32(Request.Form["LoaiSachIDLoaiSach"]);
                s.NgonNguIDNgonNgu = Convert.ToInt32(Request.Form["NgonNguIDNgonNgu"]);
                s.NhaXuatBanIDNXB = Convert.ToInt32(Request.Form["NhaXuatBanIDNXB3"]);
                s.TacGiaIDTacGia = Convert.ToInt32(Request.Form["TacGiaIDTacGia"]);
                s.ViTriIDViTri = Convert.ToInt32(Request.Form["ViTriIDViTri"]);
                sach.active = true;

                HttpPostedFileBase file = Request.Files["Image"];
                if (file != null)
                {
                    string svPath = HttpContext.Server.MapPath("~/Content/images");
                    string filePath = svPath + "/" + file.FileName;
                    file.SaveAs(filePath);
                    sach.Image = file.FileName;
                }

                db.Saches.InsertOnSubmit(sach);
                db.SubmitChanges();
                return RedirectToAction("QuanLySachBan", "QuanLySachBan", new { area = "PageManagement" });

            }
            return View();
        }



        public ActionResult Delete(int id)
        {
            Sach s = db.Saches.FirstOrDefault(x => x.IDSach == id);
            if (s != null)
            {
                db.DeleteSachBan(s.IDSach);
            }
            return RedirectToAction("QuanLySachBan");
        }

        public ActionResult SuaSachBan(int id)
        {
            TempData["AllLoaiSach"] = db.AllLoaiSach().ToList();
            TempData["AllNXB"] = db.AllNXB().ToList();
            TempData["AllNgonNgu"] = db.AllNgonNgu().ToList();
            TempData["AllTacGia"] = db.AllTacGia().ToList();
            TempData["AllViTri"] = db.AllViTri().ToList();
            Sach s = db.Saches.FirstOrDefault(x => x.IDSach == id);
            return View(s);
        }

        [HttpPost]
        public ActionResult SuaSachBan(int id, Sach sach)
        {
            Sach s = db.Saches.FirstOrDefault(x => x.IDSach == id);
            if (s != null)
            {
                s.MaSach = sach.MaSach;
                s.TenSach = sach.TenSach;
                s.NamXB = sach.NamXB;
                s.TaiBan = sach.TaiBan;
                s.GiaBan = sach.GiaBan;
                s.Metakeyword = sach.Metakeyword;
                s.MetaDescription = sach.MetaDescription;
                s.TrangThai = sach.TrangThai;
                s.LoaiSachIDLoaiSach = sach.LoaiSachIDLoaiSach;
                s.NgonNguIDNgonNgu = sach.NgonNguIDNgonNgu;
                s.NhaXuatBanIDNXB = sach.NhaXuatBanIDNXB;
                s.TacGiaIDTacGia = sach.TacGiaIDTacGia;
                s.ViTriIDViTri = sach.ViTriIDViTri;
                HttpPostedFileBase file = Request.Files["Image"];
                if (file != null)
                {
                    string svPath = HttpContext.Server.MapPath("~/Content/images");
                    string filePath = svPath + "/" + file.FileName;
                    file.SaveAs(filePath);
                    s.Image = file.FileName;
                }
                db.SubmitChanges();
            }
            return RedirectToAction("QuanLySachBan");
        }

        //public ActionResult procDetail(int id)
        //{
        //    CSDLDataContext db = new CSDLDataContext();
        //    ChiTietSachResult sach = db.ChiTietSach(id).FirstOrDefault();
        //    return View(sach);
        //}

    }
}