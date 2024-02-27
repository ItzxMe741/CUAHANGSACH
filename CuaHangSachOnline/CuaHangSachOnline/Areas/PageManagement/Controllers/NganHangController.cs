using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class NganHangController : Controller
    {
        // GET: PageManagement/NganHang
        CSDLDataContext db = new CSDLDataContext();
        public ActionResult Index()
        {
            List<AllNganHangResult> lstnh = db.AllNganHang().ToList();
            return View(lstnh);
        }

        public ActionResult Create()
        {
            TempData["AllHTTT"] = db.AllHTTT().ToList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(NganHang nh)
        {

            db.AddNganHang(nh.MaNganHang, nh.TenNganHang,Convert.ToInt32(nh.HinhThucThanhToanIDHTTT));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            NganHang nh = db.NganHangs.FirstOrDefault(x => x.IDNganHang == id);
            if (nh != null)
            {
                db.DeleteNH(id);
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
            Get_NH_forIDResult nh = db.Get_NH_forID(id).FirstOrDefault();
            TempData["AllHTTT"] = db.AllHTTT().ToList();
            if (Request.Form.Count > 0)
            {
                string MaNganHang = Request.Form["MaNganHang"];
                string TenNganHang = Request.Form["TenNganHang"];
                int HinhThucThanhToanIDHTTT = Convert.ToInt32(Request.Form["HinhThucThanhToanIDHTTT"]);
                db.EditNganHang(nh.IDNganHang,MaNganHang, TenNganHang, HinhThucThanhToanIDHTTT);
                db.SubmitChanges();
                TempData["AlertMessage"] = " Cập nhật thành công";
                return RedirectToAction("Index");
            }

            return View(nh);
        }
    }
}