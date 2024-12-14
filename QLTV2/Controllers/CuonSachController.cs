using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTV2.Models;
using QLTV2.Repository;

namespace QLTV2.Controllers
{
    [Authorize]
    public class CuonSachController : Controller
    {
        private readonly DataContext _context;

        public CuonSachController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searchTerm, int page = 1, int pageSize = 5)
        {
            ViewBag.ListTuaSach = _context.TuaSaches.ToList();
            ViewBag.ListDocGia = _context.DocGias.ToList();
            ViewBag.ListThuVien = _context.ThuViens.ToList();

            var query = _context.CuonSaches
                .Include(cs => cs.TuaSach) // Nối với TuaSach
                .Include(cs => cs.ThuVien) // Nối với ThuVien
                .AsQueryable();

            // Tìm kiếm theo các trường
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(cs => cs.TuaSach.TenTuaSach.Contains(searchTerm) ||
                                           cs.ThuVien.TenThuVien.Contains(searchTerm) ||
                                           cs.TuaSach.NhaXuatBan.TenNXB.Contains(searchTerm) ||
                                           cs.ThuVien.MaThuVien.ToString().Contains(searchTerm) ||
                                           cs.TuaSach.TuaSachID.ToString().Contains(searchTerm));
            }
            // Tính tổng số bản ghi
            var totalItems = query.Count();
            // Phân trang
            var cuonSachs = query
                .OrderBy(cs => cs.TuaSach.TenTuaSach)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            // Gửi thông tin phân trang đến View
            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;
            return View(cuonSachs);
        }
        [HttpPost]
        public IActionResult Create(CuonSach cuonSach)
        {
            _context.CuonSaches.Add(cuonSach);
            _context.SaveChanges();

            // Sau khi thêm thành công, chuyển hướng về trang danh sách
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int MaTuaSach, int MaThuVien, int SoLuong)
        {
            var cuonSach = await _context.CuonSaches
                .FirstOrDefaultAsync(cs => cs.MaTuaSach == MaTuaSach && cs.MaThuVien == MaThuVien);

            if (cuonSach == null)
            {
                return NotFound();
            }
            cuonSach.SoLuong = SoLuong;
            _context.CuonSaches.Update(cuonSach);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int MaTuaSach, int MaThuVien)
        {
            var cuonSach = await _context.CuonSaches
                .FirstOrDefaultAsync(cs => cs.MaTuaSach == MaTuaSach && cs.MaThuVien == MaThuVien);

            if (cuonSach == null)
            {
                return NotFound();
            }

            _context.CuonSaches.Remove(cuonSach);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
