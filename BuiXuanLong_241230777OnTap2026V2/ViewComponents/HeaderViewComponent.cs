using Microsoft.AspNetCore.Mvc;
using BuiXuanLong_241230777OnTap2026V2.Service;


namespace BuiXuanLong_241230777OnTap2026V2.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {

        private readonly QLNhaSachService _sv;

        public HeaderViewComponent(QLNhaSachService sv)
        {
            _sv = sv;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _sv.GetAllTheLoai();
            return View(data);
        }
    }
}
