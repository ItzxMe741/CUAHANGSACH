using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class ViTriSachController : Controller
    {
        CSDLDataContext db = new CSDLDataContext();
        public ActionResult ViTriSach()
        {
            List<AllViTriResult> lstloaisach = db.AllViTri().ToList();
            return View(lstloaisach);
        }

        public ActionResult ThemViTri()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemViTri(ViTri vitri)
        {


            if (Request.Form.Count > 0)
            {
                AllViTriResult vt = new AllViTriResult();
                vt.Khu = Request.Form["Khu"];
                vt.Ke = Request.Form["Ke"];
                vt.Tang = Request.Form["Tang"];

                db.ViTris.InsertOnSubmit(vitri);
                db.SubmitChanges();
                return RedirectToAction("ViTriSach", "ViTriSach", new { area = "PageManagement" });

            }
            return View();
        }



        public ActionResult Delete(int id)
        {
            ViTri ls = db.ViTris.FirstOrDefault(x => x.IDViTri == id);
            if (ls != null)
            {
                db.DeleteViTri(ls.IDViTri);
            }
            return RedirectToAction("ViTriSach");
        }

        public ActionResult SuaViTri(int id)
        {
            ViTri ls = db.ViTris.FirstOrDefault(x => x.IDViTri == id);
            return View(ls);
        }

        [HttpPost]
        public ActionResult SuaViTri(int id, ViTri vitri)
        {
            ViTri vt = db.ViTris.FirstOrDefault(x => x.IDViTri == id);
            if (vt != null)
            {
                vt.Khu = vitri.Khu;
                vt.Ke = vitri.Ke;
                vt.Tang = vitri.Tang;
                db.SubmitChanges();
            }
            return RedirectToAction("ViTriSach");
        }

        //public ActionResult procDetail(int id)
        //{
        //    CSDLDataContext db = new CSDLDataContext();
        //    ChiTietSachResult sach = db.ChiTietSach(id).FirstOrDefault();
        //    return View(sach);
        //}

    }
}