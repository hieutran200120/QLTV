using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLTV2.Models;
using QLTV2.Repository;

namespace QLTV2.Controllers
{
    [Authorize]
    public class MuonSachController : Controller
    {

        private readonly DataContext _context;

        public MuonSachController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search, DateTime? dateMuon, DateTime? dateTra, int page = 1, int pageSize = 5)
        {
            var query = _context.MuonSaches
                .Include(ms => ms.TuaSach)
                .Include(ms => ms.ThuVien)
                .Include(ms => ms.DocGia)
                .AsQueryable();

            // Tìm kiếm theo tên tựa sách, tên thư viện, tên độc giả nếu có
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(ms =>
                    ms.TuaSach.TenTuaSach.Contains(search) ||
                    ms.ThuVien.TenThuVien.Contains(search) ||
                    ms.DocGia.TenDG.Contains(search));
            }

            // Lọc theo ngày mượn (chỉ chọn những bản ghi có ngày mượn đúng bằng dateMuon)
            if (dateMuon.HasValue)
            {
                // Vì NgayMuon có kiểu DateTime, bạn có thể so sánh Date riêng biệt.
                // Ví dụ: So sánh NgayMuon.Date == dateMuon.Value.Date
                query = query.Where(ms => ms.NgayMuon.Date == dateMuon.Value.Date);
            }

            // Lọc theo ngày trả (chỉ chọn những bản ghi có ngày trả đúng bằng dateTra)
            if (dateTra.HasValue)
            {
                query = query.Where(ms => ms.NgayTra.HasValue && ms.NgayTra.Value.Date == dateTra.Value.Date);
            }

            int totalItems = query.Count();

            var muonSachs = query
                .OrderBy(ms => ms.NgayMuon)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = totalItems;
            ViewBag.Search = search;
            ViewBag.DateMuon = dateMuon?.ToString("yyyy-MM-dd");
            ViewBag.DateTra = dateTra?.ToString("yyyy-MM-dd");

            ViewBag.ListTuaSach = _context.TuaSaches.ToList();
            ViewBag.ListDocGia = _context.DocGias.ToList();
            ViewBag.ListThuVien = _context.ThuViens.ToList();

            return View(muonSachs);
        }
        [HttpPost]
        public IActionResult Create(MuonSach muonSach)
        {
            _context.MuonSaches.Add(muonSach);
            _context.SaveChanges();

            // Sau khi thêm thành công, chuyển hướng về trang danh sách
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult UpdateNgayTra(int id, DateTime ngayTra)
        {
            // Find the record by ID
            var muonSach = _context.MuonSaches.FirstOrDefault(ms => ms.MaTuaSach == id);

            if (muonSach == null)
            {
                // Return an error if the record does not exist
                return NotFound(new { message = "Không tìm thấy mượn sách cần cập nhật." });
            }

            // Update the NgayTra field
            muonSach.NgayTra = ngayTra;

            // Save changes to the database
            _context.SaveChanges();

            // Redirect back to the Index view after successful update
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int maTuaSach, int maThuVien, int soTheDG)
        {
            var muonSach = _context.MuonSaches
                .FirstOrDefault(ms => ms.MaTuaSach == maTuaSach && ms.MaThuVien == maThuVien && ms.SoTheDG == soTheDG);

            if (muonSach == null)
            {
                return NotFound(new { message = "Không tìm thấy mượn sách cần xóa." });
            }

            _context.MuonSaches.Remove(muonSach);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}
