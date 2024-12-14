using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QLTV2.Models;
using System.Threading.Tasks;

namespace QLTV2.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUserModel> _signInManager;
        private readonly ILogger<LoginController> _logger;

        public LoginController(SignInManager<AppUserModel> signInManager, ILogger<LoginController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View(new TaiKhoanModel());
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(TaiKhoanModel loginInfo)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginInfo.UserName, loginInfo.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "TuaSach");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
                // Trả lại view với cùng model để hiển thị lại lỗi
                return View("Index", loginInfo);
            }
        }
    }
}
