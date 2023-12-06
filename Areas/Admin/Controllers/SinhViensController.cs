using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLiKyTucXa.Models;

namespace QuanLiKyTucXa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SinhViensController : Controller
    {
        private readonly QlktxContext _context;

        public SinhViensController(QlktxContext context)
        {
            _context = context;
        }

        // GET: Admin/SinhViens
        public async Task<IActionResult> Index()
        {
            var qlktxContext = _context.SinhViens.Include(s => s.MpNavigation);
            return View(await qlktxContext.ToListAsync());
        }

        // GET: Admin/SinhViens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SinhViens == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.MpNavigation)
                .FirstOrDefaultAsync(m => m.Mssv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Create
        public IActionResult Create()
        {
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc");
            return View();
        }

        // POST: Admin/SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mssv,HoTen,GioiTinh,NgaySinh,Lop,Khoa,Sdt,Mp,SoGiuong,MatKhau")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", sinhVien.Mp);
            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.SinhViens == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", sinhVien.Mp);
            return View(sinhVien);
        }

        // POST: Admin/SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mssv,HoTen,GioiTinh,NgaySinh,Lop,Khoa,Sdt,Mp,SoGiuong,MatKhau")] SinhVien sinhVien)
        {
            if (id != sinhVien.Mssv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.Mssv))
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
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", sinhVien.Mp);
            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SinhViens == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.MpNavigation)
                .FirstOrDefaultAsync(m => m.Mssv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: Admin/SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SinhViens == null)
            {
                return Problem("Entity set 'QlktxContext.SinhViens'  is null.");
            }
            var sinhVien = await _context.SinhViens.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhViens.Remove(sinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
          return (_context.SinhViens?.Any(e => e.Mssv == id)).GetValueOrDefault();
        }
    }
}
