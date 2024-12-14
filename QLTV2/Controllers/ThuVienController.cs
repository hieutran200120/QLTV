using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLTV2.Models;
using QLTV2.Repository;

namespace QLTV2.Controllers
{
    [Authorize]
    public class ThuVienController : Controller
    {
        private readonly DataContext _context;

        public ThuVienController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchTerm, int page = 1, int pageSize = 5)
        {
            // Lấy danh sách thư viện từ cơ sở dữ liệu
            var query = _context.ThuViens.AsQueryable();

            // Lọc theo tên thư viện hoặc địa chỉ nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(tv => tv.TenThuVien.Contains(searchTerm) || tv.DiaChi.Contains(searchTerm));
            }

            // Tổng số bản ghi (để hỗ trợ phân trang)
            var totalItems = query.Count();

            // Phân trang
            var thuVienList = query
                .OrderBy(tv => tv.TenThuVien)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Gửi thông tin phân trang đến View
            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;

            return View(thuVienList);
        }
        [HttpPost]
        public async Task<IActionResult> Create( ThuVien thuVien)
        {
            try
            {
                _context.Add(thuVien);
                await _context.SaveChangesAsync();  

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the category: " + ex.Message);
            }

            return View(thuVien);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int MaThuVien, string TenThuVien, string DiaChi)
        {
            if (ModelState.IsValid)
            {
                var thuViens = await _context.ThuViens.FindAsync(MaThuVien);
                if (thuViens == null)
                {
                    return NotFound();
                }

                thuViens.TenThuVien = TenThuVien;
                thuViens.DiaChi = DiaChi;

                _context.Update(thuViens);
                await _context.SaveChangesAsync();

                // Chuyển hướng sau khi lưu thành công
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var thuViens = await _context.ThuViens.FindAsync(id);
            if (thuViens == null)
            {
                return NotFound();
            }

            _context.ThuViens.Remove(thuViens);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
