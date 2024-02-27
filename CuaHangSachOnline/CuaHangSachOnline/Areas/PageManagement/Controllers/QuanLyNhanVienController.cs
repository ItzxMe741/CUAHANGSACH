using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
       
            CSDLDataContext db = new CSDLDataContext();

            public ActionResult QuanLyNhanVien()
            {
            List <AllNHANVIENResult> lstnv = db.AllNHANVIEN().ToList();
                return View(lstnv);
            }

            public ActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public ActionResult Create(NhanVien nv)
            {
                
                db.AddNhanVien(nv.MaNhanVien, nv.TenNhanVien, nv.Email, Convert.ToDateTime(nv.NgaySinh), nv.Sdt, nv.UserName, nv.Password, Convert.ToInt32(nv.QuyenNV));
                return RedirectToAction("QuanLyNhanVien");
            }

            public ActionResult Delete(int id)
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(x => x.IDNhanVien == id);
                if (nv != null)
                {
                    db.DELETENHANVIEN(nv.IDNhanVien);
                }
                return RedirectToAction("QuanLyNhanVien");
            }

            //public ActionResult Edit(int id)
            //{
            //    var data = db.NhanViens.FirstOrDefault(x => x.IDNhanVien == id);
            //    return View(data);
            //}

            public ActionResult Edit(int id)
            {
                GetNVforIDResult nv = db.GetNVforID(id).FirstOrDefault();
                if (Request.Form.Count > 0)
                {
                    string MaNhanVien = Request.Form["MaNhanVien"];
                    string TenNhanVien = Request.Form["TenNhanVien"];
                    string Email = Request.Form["Email"];
                    DateTime NgaySinh = DateTime.Parse(Request.Form["NgaySinh"]);
                    string Sdt = Request.Form["Sdt"];
                    db.EditNhanVien(nv.IDNhanVien,MaNhanVien,TenNhanVien,Email,NgaySinh,Sdt);
                    db.SubmitChanges();
                    TempData["AlertMessage"] = " Cập nhật thành công";
                    return RedirectToAction("QuanLyNhanVien");
                }

                return View(nv);
            }

                public ActionResult EditTkNhanVien(int id)
                {
                    GetNVforIDResult nv = db.GetNVforID(id).FirstOrDefault();
                    if (Request.Form.Count > 0)
                    {
                        string UserName = Request.Form["UserName"];
                        string Password = Request.Form["Password"];
                        string QuyenNV = Request.Form["QuyenNV"];
                        db.EditTkNhanVien(nv.IDNhanVien, UserName, Password, Convert.ToInt32(QuyenNV));
                        db.SubmitChanges();
                        TempData["AlertMessage"] = " Cập nhật thành công";
                        return RedirectToAction("QuanLyNhanVien");
                    }

                    return View(nv);
                }

            }
    }

