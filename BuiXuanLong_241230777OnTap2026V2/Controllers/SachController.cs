using BuiXuanLong_241230777OnTap2026V2.Models;
using BuiXuanLong_241230777OnTap2026V2.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuiXuanLong_241230777OnTap2026V2.Controllers
{
    public class SachController : Controller
    {
        private readonly QLNhaSachService _sv;
        public SachController(QLNhaSachService sv)
        {
            _sv = sv;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var theloai = await _sv.GetAllTheLoai();
            ViewBag.TheLoai = new SelectList(theloai,"MaTl","TenTl");
            return View(new Sach());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sach sach)
        {

            if (ModelState.IsValid)
            {
                await _sv.Create(sach);
                return RedirectToAction("Index","Home");
            }

            var theloai = await _sv.GetAllTheLoai();
            ViewBag.TheLoai = new SelectList(theloai, "MaTl", "TenTl");
            return View(new Sach());
        }
    }
}
