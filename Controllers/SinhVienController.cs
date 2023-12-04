using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLiKyTucXa.Models;

namespace QuanLiKyTucXa.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly QlktxContext _context;

        public SinhVienController(QlktxContext context)
        {
            _context = context;
        }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
            string username = HttpContext.Session.GetString("Username");

            if  (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Auth");
            }

            var sinhVien = _context.SinhViens.SingleOrDefault(p => p.Mssv == username);

            if (sinhVien == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            return View(sinhVien);
        }
    }
}
