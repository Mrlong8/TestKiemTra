using BuiXuanLong_241230777OnTap2026V2.Models;
using BuiXuanLong_241230777OnTap2026V2.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuiXuanLong_241230777OnTap2026V2.Controllers
{
    public class HomeController : Controller
    {

        private readonly QLNhaSachService _sv;
        public HomeController(QLNhaSachService sv)
        {
            _sv = sv;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _sv.GetAllSach();
            ViewBag.TheLoai = "Bùi Xuân Long";
            return View(data);
        }

        public async Task<IActionResult> FilterSach(int? maTL)
        {
            if(maTL == null)
            {
                var data1 = await _sv.GetAllSach();
                ViewBag.TheLoai = "Bùi Xuân Long";
                return PartialView("BuiXuanLong_MainContent",data1);
            }

            var data = await _sv.GetAllSachByID(maTL.Value);
            var theloai = await _sv.GetTheLoaiByID(maTL.Value);

            ViewBag.TheLoai = theloai?.TenTl;
            return PartialView("BuiXuanLong_MainContent", data);
        }


        
        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
