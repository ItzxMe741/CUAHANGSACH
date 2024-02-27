using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CuaHangSachOnline.Models;

namespace CuaHangSachOnline.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        CSDLDataContext db = new CSDLDataContext();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register re)
        {
            if (ModelState.IsValid)
            {
                
                var check = db.KhachHangs.FirstOrDefault(s => s.Username == re.Username);
                if (check == null)
                {
                    //re.MATKHAU = GetMD5(re.MATKHAU);
                    //con.Configuration.ValidateOnSaveEnabled = false;
                    if (Request.Form.Count > 0)
                    {
                        string Username = Request.Form["Username"];
                        string Password = Request.Form["Password"];
                        string ConfirmPassword = Request.Form["ConfirmPassword"];
                        string Email = Request.Form["Email"];
                        string Sdt = Request.Form["Sdt"];



                        KhachHang kh = new KhachHang();
                        kh.Username = Username;
                        kh.Password = GetMD5(Password);
                        kh.Email = Email;
                        kh.Sdt = Sdt;

                        if (ConfirmPassword != Password)
                        {
                            TempData["AlertMessage"] = " Mật khẩu và mật khẩu nhập lại không giống nhau";
                            return View();
                        }
                        else
                        {
                            db.DANGKYTAIKHOAN(kh.Username,kh.Password,kh.Email,kh.Sdt);
                            db.SubmitChanges();
                            return RedirectToAction("Index", "Home");
                        }

                    }
                }
                else
                {

                    TempData["AlertMessage"] = " Tài khoản này đã tồn tại";
                    return View();
                }
            }
            ////return RedirectToAction("Index");

            return View();

        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
        [ValidateInput(true)]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(Password);
                var data = db.KhachHangs.Where(s => s.Username.Equals(Username) && s.Password.Equals(f_password)).ToList();
                var data2 = db.KhachHangs.Where(s => s.Username.Equals(Username) && s.Password.Equals(Password)).ToList();
                var data1 = db.NhanViens.Where(s => s.UserName.Equals(Username) && s.Password.Equals(Password)).ToList();

                if (data1.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data1.FirstOrDefault().UserName;
                    Session["Email"] = data1.FirstOrDefault().Email;
                    Session["idUser"] = data1.FirstOrDefault().IDNhanVien;
                    return RedirectToAction("QuanLySachThue", "QuanLySachThue", new { area = "PageManagement" });
                }

                else if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().Username;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().IDKhach;
                    return RedirectToAction("Index", "Home");
                }
                else if (data2.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data2.FirstOrDefault().Username;
                    Session["Email"] = data2.FirstOrDefault().Email;
                    Session["idUser"] = data2.FirstOrDefault().IDKhach;
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    TempData["AlertMessage"] = "Tài khoản hoặc Mật khẩu sai!!!";
                    return RedirectToAction("Login");
                }

            }
            return View();
        }

        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index", "Home");
        }
    }
}