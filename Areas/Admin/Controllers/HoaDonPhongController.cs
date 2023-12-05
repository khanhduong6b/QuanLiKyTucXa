﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLiKyTucXa.Helper;
using QuanLiKyTucXa.Models;

namespace QuanLiKyTucXa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/HoaDonPhong/[action]")]
    public class HoaDonPhongController : Controller
    {
        private readonly QlktxContext _context;

        public HoaDonPhongController(QlktxContext context)
        {
            _context = context;
        }

        // GET: Admin/HoaDonPhong
        public async Task<IActionResult> Index()
        {
            var qlktxContext = _context.HoaDonPhongs.Include(h => h.MssvNavigation);
            return View(await qlktxContext.ToListAsync());
        }

        // GET: Admin/HoaDonPhong/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.HoaDonPhongs == null)
            {
                return NotFound();
            }

            var hoaDonPhong = await _context.HoaDonPhongs
                .Include(h => h.MssvNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);
            if (hoaDonPhong == null)
            {
                return NotFound();
            }

            return View(hoaDonPhong);
        }

        // GET: Admin/HoaDonPhong/Create
        public IActionResult Create()
        {
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv");
            return View();
        }

        // POST: Admin/HoaDonPhong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoaDon,Quy,SoTien,TrangThai,Mssv")] HoaDonPhong hoaDonPhong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDonPhong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv", hoaDonPhong.Mssv);
            return View(hoaDonPhong);
        }

        // GET: Admin/HoaDonPhong/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.HoaDonPhongs == null)
            {
                return NotFound();
            }

            var hoaDonPhong = await _context.HoaDonPhongs.FindAsync(id);
            if (hoaDonPhong == null)
            {
                return NotFound();
            }
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv", hoaDonPhong.Mssv);
            return View(hoaDonPhong);
        }

        // POST: Admin/HoaDonPhong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHoaDon,Quy,SoTien,TrangThai,Mssv")] HoaDonPhong hoaDonPhong)
        {
            if (id != hoaDonPhong.MaHoaDon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDonPhong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonPhongExists(hoaDonPhong.MaHoaDon))
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
            ViewData["Mssv"] = new SelectList(_context.SinhViens, "Mssv", "Mssv", hoaDonPhong.Mssv);
            return View(hoaDonPhong);
        }

        // GET: Admin/HoaDonPhong/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.HoaDonPhongs == null)
            {
                return NotFound();
            }

            var hoaDonPhong = await _context.HoaDonPhongs
                .Include(h => h.MssvNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);
            if (hoaDonPhong == null)
            {
                return NotFound();
            }

            return View(hoaDonPhong);
        }

        // POST: Admin/HoaDonPhong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.HoaDonPhongs == null)
            {
                return Problem("Entity set 'QlktxContext.HoaDonPhongs'  is null.");
            }
            var hoaDonPhong = await _context.HoaDonPhongs.FindAsync(id);
            if (hoaDonPhong != null)
            {
                _context.HoaDonPhongs.Remove(hoaDonPhong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonPhongExists(string id)
        {
          return (_context.HoaDonPhongs?.Any(e => e.MaHoaDon == id)).GetValueOrDefault();
        }
    }
}