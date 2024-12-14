using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLTV2.Models;
using QLTV2.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace QLTV2.Controllers
{
    [Authorize]
    public class TaiKhoanController : Controller
    {
        private readonly UserManager<AppUserModel> _userManager;
        private readonly SignInManager<AppUserModel> _signInManager;
        private readonly DataContext _context;

        public TaiKhoanController(UserManager<AppUserModel> userManager, DataContext context, SignInManager<AppUserModel> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string searchTerm, int page = 1, int pageSize = 5)
        {
            // Tạo IQueryable để có thể linh hoạt áp dụng truy vấn
            var query = _userManager.Users.AsQueryable();

            // Áp dụng tìm kiếm nếu có
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(tv => tv.UserName.Contains(searchTerm)
                                          || tv.PhoneNumber.Contains(searchTerm)
                                          || tv.Email.Contains(searchTerm));
            }

            // Đếm tổng số phần tử sau khi đã lọc
            var totalItems = await query.CountAsync();

            // Thực hiện phân trang và chọn thông tin cần thiết
            var taiKhoanList = await query
                .OrderBy(tv => tv.UserName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(user => new TaiKhoanModel
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    SDT = user.PhoneNumber
                })
                .ToListAsync();

            // Gửi thông tin phân trang và từ khóa tìm kiếm đến View
            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchTerm = searchTerm;

            return View(taiKhoanList);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TaiKhoanModel user)
        {

            // Tạo đối tượng AppUserModel từ thông tin được gửi từ form
            var newUser = new AppUserModel
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.SDT
            };

            // Tạo người dùng mới
            var createResult = await _userManager.CreateAsync(newUser, user.Password);

            if (!createResult.Succeeded)
            {
                // Nếu xảy ra lỗi khi tạo người dùng, hiển thị lỗi qua TempData
                TempData["error"] = string.Join("; ", createResult.Errors.Select(e => e.Description));
                return RedirectToAction("Index");
            }

            // Tạo thành công người dùng và vai trò
            TempData["success"] = "Tạo user và vai trò thành công!";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Logout(string returnUrl = "/Login")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}
