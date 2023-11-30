using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using QuanLiKyTucXa.Helper;
using QuanLiKyTucXa.Models;
using System.Text.Encodings.Web;

namespace QuanLiKyTucXa.Controllers
{
    [Route("/Auth/[action]")]
    public class AuthController : Controller
    {
        private readonly QlktxContext _context;
        private readonly HasPassword _hasPassword;

        public AuthController(QlktxContext context, HasPassword hasPassword)
        {
            _context = context;
            _hasPassword = hasPassword;
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(LoginVM user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = _context.SinhViens.SingleOrDefault(p => p.Mssv == user.Username);
                if (u == null) return View();

                if (u.Mssv == user.Username && u.MatKhau == _hasPassword.HasPasswordHandler(user.Password)) 
                {

                    HttpContext.Session.SetString("Username", u.Mssv.ToString());
                        return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index", "Home");
        }

    }
}
