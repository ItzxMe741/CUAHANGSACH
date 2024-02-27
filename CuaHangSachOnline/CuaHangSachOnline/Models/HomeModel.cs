using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuaHangSachOnline.Models;

namespace CuaHangSachOnline.Models
{
    public class HomeModel
    {

        public List<Sach> lstSach { get; set; }
        public List<LoaiSach> lstLoaiSach { get; set; }
    }
}