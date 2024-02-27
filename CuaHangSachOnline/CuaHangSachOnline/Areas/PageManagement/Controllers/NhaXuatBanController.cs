using CuaHangSachOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuaHangSachOnline.Areas.PageManagement.Controllers
{
    public class NhaXuatBanController : Controller
    {
        // GET: PageManagement/NhaXuatBan
        CSDLDataContext db = new CSDLDataContext();
        public ActionResult Index()
        {
            List<AllNXBResult> lstnxb = db.AllNXB().ToList();
            return View(lstnxb);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(NhaXuatBan nxb)
        {
            db.AddNXB(nxb.MaNXB,nxb.TenNXB,nxb.Email,nxb.SDT,nxb.DiaChi);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            NhaXuatBan nxb = db.NhaXuatBans.FirstOrDefault(x => x.IDNXB == id);
            if (nxb != null)
            {
                db.DeleteNXB(id);
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
            Get_NXB_forIDResult nxb = db.Get_NXB_forID(id).FirstOrDefault();
            if (Request.Form.Count > 0)
            {
                string MaNXB = Request.Form["MaNXB"];
                string TenNXB = Request.Form["TenNXB"];
                string Email = Request.Form["Email"];
                string SDT = Request.Form["SDT"];
                string DiaChi = Request.Form["DiaChi"];
                db.EditNXB(nxb.IDNXB, MaNXB, TenNXB, Email,SDT,DiaChi);
                db.SubmitChanges();
                TempData["AlertMessage"] = " Cập nhật thành công";
                return RedirectToAction("Index");
            }

            return View(nxb);
        }
    }
}