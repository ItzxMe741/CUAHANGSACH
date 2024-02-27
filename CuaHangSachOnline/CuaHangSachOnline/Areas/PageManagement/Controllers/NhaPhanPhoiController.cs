using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class NhaPhanPhoiController : Controller
    {
        // GET: PageManagement/NhaPhanPhoi
        CSDLDataContext db = new CSDLDataContext();
        public ActionResult Index()
        {
            List<AllNhaPPResult> lstnh = db.AllNhaPP().ToList();
            return View(lstnh);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(NhaPhanPhoi npp)
        {
            db.AddNhaPP(npp.MaNhaCC,npp.TenNhaCC,Convert.ToInt32(npp.MaSoThue),npp.DiaChi,npp.Sdt,npp.Email,npp.GhiChu);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            NhaPhanPhoi npp = db.NhaPhanPhois.FirstOrDefault(x => x.IDNhaPP == id);
            if (npp != null)
            {
                db.DeleteNhaCC(id);
            }
            return RedirectToAction("Index");
        }

        //public ActionResult Edit(int id)
        //{
        //    var data = db.NhanViens.FirstOrDefault(x => x.IDNhanVien == id);
        //    return View(data);
        //}

        public ActionResult Edit(int id)
        {
            Get_NhaPP_forIDResult npp = db.Get_NhaPP_forID(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string MaNhaCC = Request.Form["MaNhaCC"];
                string TenNhaCC = Request.Form["TenNhaCC"];
                string DiaChi = Request.Form["DiaChi"];
                string Sdt = Request.Form["Sdt"];
                string Email = Request.Form["Email"];
                string GhiChu = Request.Form["GhiChu"];
                int MaSoThue = Convert.ToInt32(Request.Form["MaSoThue"]);
                db.EditNhaPP(npp.IDNhaPP, MaNhaCC,TenNhaCC,MaSoThue,DiaChi,Sdt,Email,GhiChu);
                db.SubmitChanges();
                TempData["AlertMessage"] = " Cập nhật thành công";
                return RedirectToAction("Index");
            }

            return View(npp);
        }
    }
}