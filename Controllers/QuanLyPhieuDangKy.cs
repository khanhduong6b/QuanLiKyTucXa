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
    public class QuanLyPhieuDangKy : Controller
    {
        private readonly QlktxContext _context;

        public QuanLyPhieuDangKy(QlktxContext context)
        {
            _context = context;
        }

        // GET: QuanLyPhieuDangKy
        public async Task<IActionResult> Index()
        {
            var qlktxContext = _context.PhieuDangKies.Include(p => p.MssvNavigation);
            return View(await qlktxContext.ToListAsync());
        }

        // GET: QuanLyPhieuDangKy/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.PhieuDangKies == null)
            {
                return NotFound();
            }

            var phieuDangKy = await _context.PhieuDangKies
                .Include(p => p.MssvNavigation)
                .FirstOrDefaultAsync(m => m.MaHoSo == id);
            if (phieuDangKy == null)
            {
                return NotFound();
            }

            return View(phieuDangKy);
        }

        // GET: QuanLyPhieuDangKy/Create
        public IActionResult Create()
        {
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv");
            return View();
        }

        // POST: QuanLyPhieuDangKy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoSo,Mssv,TinhTrang")] PhieuDangKy phieuDangKy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phieuDangKy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv", phieuDangKy.Mssv);
            return View(phieuDangKy);
        }

        // GET: QuanLyPhieuDangKy/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.PhieuDangKies == null)
            {
                return NotFound();
            }

            var phieuDangKy = await _context.PhieuDangKies.FindAsync(id);
            if (phieuDangKy == null)
            {
                return NotFound();
            }
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv", phieuDangKy.Mssv);
            return View(phieuDangKy);
        }

        // POST: QuanLyPhieuDangKy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHoSo,Mssv,TinhTrang")] PhieuDangKy phieuDangKy)
        {
            if (id != phieuDangKy.MaHoSo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phieuDangKy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhieuDangKyExists(phieuDangKy.MaHoSo))
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
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv", phieuDangKy.Mssv);
            return View(phieuDangKy);
        }

        // GET: QuanLyPhieuDangKy/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.PhieuDangKies == null)
            {
                return NotFound();
            }

            var phieuDangKy = await _context.PhieuDangKies
                .Include(p => p.MssvNavigation)
                .FirstOrDefaultAsync(m => m.MaHoSo == id);
            if (phieuDangKy == null)
            {
                return NotFound();
            }

            return View(phieuDangKy);
        }

        // POST: QuanLyPhieuDangKy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.PhieuDangKies == null)
            {
                return Problem("Entity set 'QlktxContext.PhieuDangKies'  is null.");
            }
            var phieuDangKy = await _context.PhieuDangKies.FindAsync(id);
            if (phieuDangKy != null)
            {
                _context.PhieuDangKies.Remove(phieuDangKy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhieuDangKyExists(string id)
        {
          return (_context.PhieuDangKies?.Any(e => e.MaHoSo == id)).GetValueOrDefault();
        }
    }
}
