using BuiXuanLong_241230777OnTap2026V2.Models;
using Microsoft.EntityFrameworkCore;

namespace BuiXuanLong_241230777OnTap2026V2.Service
{
    public class QLNhaSachService
    {
        private readonly QLNhaSachContext _db;

        public QLNhaSachService(QLNhaSachContext db)
        {
            _db = db;
        }

        public async Task<List<TheLoai>> GetAllTheLoai()
        {
            return await _db.TheLoais.ToListAsync();
        }
        public async Task<TheLoai> GetTheLoaiByID(int id)
        {
            return await _db.TheLoais.FirstOrDefaultAsync(tl => tl.MaTl == id);
        }
        public async Task<List<Sach>> GetAllSach()
        {
            return await _db.Saches.Where(s => s.Gia >= 100 && s.Gia != null).ToListAsync();
        }
        public async Task<List<Sach>> GetAllSachByID(int id)
        {
            return await _db.Saches.Where(s => s.Gia >= 100 && s.Gia != null && s.MaTl == id).ToListAsync();
        }

        public async Task Create(Sach sach)
        {
            _db.Saches.Add(sach);
            await _db.SaveChangesAsync();

        }

    }
}
