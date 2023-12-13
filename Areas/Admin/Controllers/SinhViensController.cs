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
    [Route("/Admin/SinhViens/[action]")]
    //[Check]

    public class SinhViensController : Controller
    {
        private readonly QlktxContext _context;

        public SinhViensController(QlktxContext context)
        {
            _context = context;
        }

        // GET: Admin/SinhViens
        public async Task<IActionResult> Index(string search = "")
        {
            List<SinhVien> listsv = new();
            if (!string.IsNullOrEmpty(search))
            {
                listsv = await _context.SinhViens.Where(a => a.HoTen.Contains(search)).Include(s => s.MpNavigation).ToListAsync();
            }
            else
                listsv = await _context.SinhViens.Include(s => s.MpNavigation).ToListAsync();
            return View(listsv);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SinhViens == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhViens
                .Include(s => s.MpNavigation)
                .FirstOrDefaultAsync(m => m.Mssv == id);
            var hdphong = await _context.HoaDonPhongs.Include(s=>s.MssvNavigation).FirstOrDefaultAsync(m => m.Mssv == id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            ViewBag.hdphong = hdphong;
            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Create
        public IActionResult Create()
        {
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc");
            return View();
        }

        // POST: Admin/SinhViens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mssv,HoTen,GioiTinh,NgaySinh,Lop,Khoa,Sdt,Mp,SoGiuong,MatKhau,TinhTrang")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {  
                var phong = await _context.Phongs.FindAsync(sinhVien.Mp);
                if (phong != null)
                {
                    if (sinhVien.TinhTrang)
                        if (phong.SoLuongSvHienTai < phong.SoLuongSvToiDa)
                        {
                            phong.SoLuongSvHienTai++;
                            _context.Update(phong);
                            _context.Add(sinhVien);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            ModelState.AddModelError("Mp", "Phòng không còn chỗ trống");
                            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "Mp", sinhVien.Mp);
                            return View(sinhVien);
                        }
                    else
                    {
                        _context.Add(sinhVien);
                        await _context.SaveChangesAsync();
                    }
                }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", sinhVien.Mp);
            return View(sinhVien);
        }

        // GET: Admin/SinhViens/Edit/5
        [HttpGet("{id}")]
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
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "Mp", sinhVien.Mp);
            return View(sinhVien);
        }

        // POST: Admin/SinhViens/Edit/5
        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Mssv,HoTen,GioiTinh,NgaySinh,Lop,Khoa,Sdt,Mp,SoGiuong,MatKhau,TinhTrang")] SinhVien sinhVien)
        {
            if (id != sinhVien.Mssv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingSinhVien = await _context.SinhViens.FindAsync(id);
                    var existingPhong = await _context.Phongs.FindAsync(existingSinhVien.Mp);

                    if (existingSinhVien != null && existingPhong != null)
                    {
                        // Nếu đổi phòng
                        if (existingSinhVien.Mp != sinhVien.Mp)
                        {
                            var newPhong = await _context.Phongs.FindAsync(sinhVien.Mp);

                            if (newPhong != null && sinhVien.TinhTrang)
                            {
                                // Kiểm tra số lượng hiện tại và số lượng tối đa của phòng mới
                                if (newPhong.SoLuongSvHienTai < newPhong.SoLuongSvToiDa)
                                {
                                    // Giảm số lượng sinh viên hiện tại của phòng cũ
                                    existingPhong.SoLuongSvHienTai--;

                                    // Tăng số lượng sinh viên hiện tại của phòng mới
                                    newPhong.SoLuongSvHienTai++;

                                    _context.Update(existingPhong);
                                    _context.Update(newPhong);
                                }
                                else
                                {
                                    ModelState.AddModelError("Mp", "Phòng không còn chỗ trống");
                                    ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", sinhVien.Mp);
                                    return View(sinhVien);
                                }
                            }
                        }

                        // Nếu đổi tình trạng nhưng không đổi phòng
                        if (existingSinhVien.TinhTrang != sinhVien.TinhTrang)
                        {
                            if (sinhVien.TinhTrang)
                            {
                                // Tăng số lượng sinh viên hiện tại của phòng
                                existingPhong.SoLuongSvHienTai++;
                                _context.Update(existingPhong);
                            }
                            else
                            {
                                // Giảm số lượng sinh viên hiện tại của phòng
                                existingPhong.SoLuongSvHienTai--;
                                _context.Update(existingPhong);
                            }
                        }
                    }

                    // Cập nhật thông tin sinh viên
                    _context.Entry(existingSinhVien).CurrentValues.SetValues(sinhVien);
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
        [HttpGet("{id}")]
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

            var a = _context.HoaDonPhongs.Where(h => h.Mssv == id).ToList().Count;
            var b = _context.PhieuDangKies.Where(p => p.Mssv == id).ToList().Count;
            if (a > 0 || b>0)
            {
                ViewBag.Delete = false;
            }
            else ViewBag.Delete = true;

            return View(sinhVien);
        }

        // POST: Admin/SinhViens/Delete/5
        [HttpPost("{id}"), ActionName("Delete")]
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
                var phong = await _context.Phongs.FindAsync(sinhVien.Mp);
                if (phong != null && sinhVien.TinhTrang) {
                    phong.SoLuongSvHienTai--;
                    _context.Phongs.Update(phong);
                }

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
