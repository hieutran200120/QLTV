using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTV2.Models;
using QLTV2.Repository;

namespace QLTV2.Controllers
{
    [Authorize]
    public class TuaSachController : Controller
    {
        private readonly DataContext _context;

        public TuaSachController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchTerm, int page = 1, int pageSize = 5)
        {
            ViewBag.ListNhaXuatBans = _context.NhaXuatBans.ToList();

            var query = _context.SachTacGias
                .Include(stg => stg.TuaSach)  // Include để nạp dữ liệu từ TuaSach
                .AsQueryable();

            // Tìm kiếm theo tên tựa sách, tên tác giả và tên nhà xuất bản
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(stg => stg.TuaSach.TenTuaSach.Contains(searchTerm) ||
                                           stg.TenTacGia.Contains(searchTerm) ||
                                           (stg.TuaSach.NhaXuatBan != null && stg.TuaSach.NhaXuatBan.TenNXB.Contains(searchTerm)));
            }
            // Tính tổng số bản ghi
            var totalItems = query.Count();

            // Phân trang
            var sachTacGias = query
                .OrderBy(stg => stg.TuaSach.TenTuaSach) // Sắp xếp theo tên tựa sách
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Gửi thông tin phân trang đến View
            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;

            return View(sachTacGias);
        }
        [HttpPost]
        public IActionResult Create(TuaSach tuaSach, string tenTacGia)
        {
                _context.TuaSaches.Add(tuaSach);
                _context.SaveChanges();

                // Thêm tác giả liên quan (nếu có)
                if (!string.IsNullOrEmpty(tenTacGia))
                {
                    var sachTacGia = new SachTacGia
                    {
                        TuaSachID = tuaSach.TuaSachID,
                        TenTacGia = tenTacGia
                    };
                    _context.SachTacGias.Add(sachTacGia);
                    _context.SaveChanges();
                }

                // Sau khi thêm thành công, chuyển hướng về trang danh sách
                return RedirectToAction(nameof(Index));
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, TuaSach tuaSach, string tenTacGia)
        {
            if (id != tuaSach.TuaSachID)
            {
                return NotFound();
            }
                try
                {
                    // Cập nhật thông tin Tựa Sách
                    _context.Update(tuaSach);
                    await _context.SaveChangesAsync();

                    // Xử lý thông tin SachTacGia
                    var sachTacGia = await _context.SachTacGias
                        .FirstOrDefaultAsync(stg => stg.TuaSachID == tuaSach.TuaSachID);

                    if (!string.IsNullOrEmpty(tenTacGia))
                    {
                        if (sachTacGia != null)
                        {
                            // Xóa thực thể cũ
                            _context.SachTacGias.Remove(sachTacGia);
                            await _context.SaveChangesAsync();

                            // Tạo thực thể mới
                            var newSachTacGia = new SachTacGia
                            {
                                TuaSachID = tuaSach.TuaSachID,
                                TenTacGia = tenTacGia
                            };
                            _context.SachTacGias.Add(newSachTacGia);
                        }
                        else
                        {
                            // Thêm mới nếu chưa tồn tại
                            var newSachTacGia = new SachTacGia
                            {
                                TuaSachID = tuaSach.TuaSachID,
                                TenTacGia = tenTacGia
                            };
                            _context.SachTacGias.Add(newSachTacGia);
                        }

                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TuaSachExists(tuaSach.TuaSachID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
          
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int TuaSachID)
        {
            // Tìm Tựa Sách theo ID
            var tuaSach = await _context.TuaSaches.FindAsync(TuaSachID);
            if (tuaSach == null)
            {
                return NotFound();
            }
            // Xóa các SachTacGia liên quan nếu tồn tại
            var sachTacGias = _context.SachTacGias.Where(stg => stg.TuaSachID == TuaSachID).ToList();
            if (sachTacGias.Any())
            {
                _context.SachTacGias.RemoveRange(sachTacGias);
            }
            // Xóa Tựa Sách
            _context.TuaSaches.Remove(tuaSach);
            await _context.SaveChangesAsync();
            // Chuyển hướng về trang Index
            return RedirectToAction(nameof(Index));
        }

        private bool TuaSachExists(int id)
        {
            return _context.TuaSaches.Any(e => e.TuaSachID == id);
        }

    }
}
