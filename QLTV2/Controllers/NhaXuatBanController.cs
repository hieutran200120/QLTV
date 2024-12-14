using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTV2.Models;
using QLTV2.Repository;

namespace QLTV2.Controllers
{
    [Authorize]
    public class NhaXuatBanController : Controller
    {
        private readonly DataContext _context;

        public NhaXuatBanController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searchTerm, int page = 1, int pageSize = 5)
        {
            // Lấy danh sách thư viện từ cơ sở dữ liệu
            var query = _context.NhaXuatBans.AsQueryable();

            // Lọc theo tên thư viện hoặc địa chỉ nếu có từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(nxb => nxb.DiaChiNXB.Contains(searchTerm) || nxb.TenNXB.Contains(searchTerm) || nxb.SDTNXB.Contains(searchTerm));
            }

            // Tổng số bản ghi (để hỗ trợ phân trang)
            var totalItems = query.Count();

            // Phân trang
            var nhaXuatBanList = query
                .OrderBy(nxb => nxb.TenNXB)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Gửi thông tin phân trang đến View
            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;

            return View(nhaXuatBanList);
        }
        [HttpPost]
        public async Task<IActionResult> Create(NhaXuatBan nxb)
        {
            try
            {
                _context.Add(nxb);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while saving the category: " + ex.Message);
            }

            return View(nxb);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string TenNXB, string DiaChiNXB, string SDTNXB)
        {
            if (ModelState.IsValid)
            {
                var nhaXuatBans = await _context.NhaXuatBans.FindAsync(TenNXB);
                if (nhaXuatBans == null)
                {
                    return NotFound();
                }

                nhaXuatBans.TenNXB = TenNXB;
                nhaXuatBans.DiaChiNXB = DiaChiNXB;
                nhaXuatBans.SDTNXB = SDTNXB;

                _context.Update(nhaXuatBans);
                await _context.SaveChangesAsync();

                // Chuyển hướng sau khi lưu thành công
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string TenNXB)
        {
            var nhaXuatBans = await _context.NhaXuatBans.FindAsync(TenNXB);
            if (nhaXuatBans == null)
            {
                return NotFound();
            }

            _context.NhaXuatBans.Remove(nhaXuatBans);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
