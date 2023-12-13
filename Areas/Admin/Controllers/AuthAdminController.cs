using Microsoft.AspNetCore.Mvc;
using QuanLiKyTucXa.Helper;
using QuanLiKyTucXa.Models;

namespace QuanLiKyTucXa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/AuthAdmin/[action]")]
    public class AuthAdminController : Controller
    {
        private readonly QlktxContext _context;
        private readonly HasPassword _hasPassword;

        public AuthAdminController(QlktxContext context, HasPassword hasPassword)
        {
            _context = context;
            _hasPassword = hasPassword;
        }
        public IActionResult LoginAdmin()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "HomeAdmin");
            }
        }

        [HttpPost]
        public IActionResult LoginAdmin(LoginVM user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = _context.AdminAccounts.SingleOrDefault(p => p.TaiKhoan == user.Username);
                if (u == null) return View();

                if (u.TaiKhoan == user.Username && u.MatKhau == user.Password)
                {

                    HttpContext.Session.SetString("Username", u.TaiKhoan.ToString());
                    return RedirectToAction("Index", "HomeAdmin");
                }
            }
            return RedirectToAction("LoginAdmin", "AuthAdmin", new { Areas = "Admin" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Auth");
        }
    }
}
