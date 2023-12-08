using System;
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
    [Route("/Admin/Phongs/[action]")]
    //[Check]

    public class PhongsController : Controller
    {
        private readonly QlktxContext _context;

        public PhongsController(QlktxContext context)
        {
            _context = context;
        }

        // GET: Admin/Phongs
        public async Task<IActionResult> Index()
        {
            var qlktxContext = _context.Phongs.Include(p => p.KhuVucNavigation);
            return View(await qlktxContext.ToListAsync());
        }

        // GET: Admin/Phongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Phongs == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.KhuVucNavigation)
                .FirstOrDefaultAsync(m => m.Mp == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }

        // GET: Admin/Phongs/Create
        public IActionResult Create()
        {
            ViewData["KhuVuc"] = new SelectList(_context.Khus, "KhuVuc", "KhuVuc");
            return View();
        }

        // POST: Admin/Phongs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mp,SoLuongSvToiDa,SoLuongSvHienTai,KhuVuc")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KhuVuc"] = new SelectList(_context.Khus, "KhuVuc", "KhuVuc", phong.KhuVuc);
            return View(phong);
        }


        // GET: Admin/Phongs/Edit/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Phongs == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            ViewData["KhuVuc"] = new SelectList(_context.Khus, "KhuVuc", "KhuVuc", phong.KhuVuc);
            return View(phong);
        }

        // POST: Admin/Phongs/Edit/5
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Phong phong)
        {
            if (id != phong.Mp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongExists(phong.Mp))
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
            ViewData["KhuVuc"] = new SelectList(_context.Khus, "KhuVuc", "KhuVuc", phong.KhuVuc);
            return View(phong);
        }


        // GET: Admin/Phongs/Delete/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Phongs == null)
            {
                return NotFound();
            }

            var phong = await _context.Phongs
                .Include(p => p.KhuVucNavigation)
                .FirstOrDefaultAsync(m => m.Mp == id);
            if (phong == null)
            {
                return NotFound();
            }

            return View(phong);
        }


        // POST: Admin/Phongs/Delete/5
        [HttpPost("{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Phongs == null)
            {
                return Problem("Entity set 'QlktxContext.Phongs'  is null.");
            }
            var phong = await _context.Phongs.FindAsync(id);
            if (phong != null)
            {
                _context.Phongs.Remove(phong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhongExists(int id)
        {
          return (_context.Phongs?.Any(e => e.Mp == id)).GetValueOrDefault();
        }
    }
}
