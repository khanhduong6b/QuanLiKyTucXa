﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using QuanLiKyTucXa.Helper;
using QuanLiKyTucXa.Models;
using SelectPdf;

namespace QuanLiKyTucXa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/HoaDons/[action]")]
    //[Check]
    public class HoaDonsController : Controller
    {
        private readonly QlktxContext _context;
        private ICompositeViewEngine _compositiveViewEngine;

        public HoaDonsController(QlktxContext context, ICompositeViewEngine compositiveViewEngine)
        {
            _context = context;
            _compositiveViewEngine = compositiveViewEngine;
        }

        // GET: Admin/HoaDons
        public async Task<IActionResult> Index(string search = "")
        {
            List<HoaDon> listHD = new();
            if (!string.IsNullOrEmpty(search))
            {
                listHD = await _context.HoaDons.Where(a => a.Thang.ToString().Contains(search)).Include(s => s.MpNavigation).ToListAsync();
            }
            else
                listHD = await _context.HoaDons.Include(h => h.MpNavigation).ToListAsync();
            return View(listHD);
        }

        // GET: Admin/HoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HoaDons == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.MpNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Create
        public IActionResult Create(int ?id = null)
        {
            if (id != null)
            {
                var checkMp = _context.Phongs.SingleOrDefault(p => p.Mp == id);
                if (checkMp != null)
                {
                    ViewData["MpFormHD"] = checkMp;
                    ViewBag.MaPhong = id;
                    var hd = _context.HoaDons.OrderByDescending(hd => hd.Thang).FirstOrDefault(hd => hd.Mp==id);
                    if (hd != null)
                    {
                        ViewBag.chiSoDau = hd.ChiSoCuoi;
                    }
                    else ViewBag.chiSoDau = 0;
                }
            }
            else
                ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc");
            return View();
        }

        // POST: Admin/HoaDons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoaDon,Thang,ChiSoDau,ChiSoCuoi,GiaDien,GiaNuoc,TrangThai,Mp")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", hoaDon.Mp);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HoaDons == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", hoaDon.Mp);
            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHoaDon,Thang,ChiSoDau,ChiSoCuoi,GiaDien,GiaNuoc,TrangThai,Mp")] HoaDon hoaDon)
        {
            if (id != hoaDon.MaHoaDon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.MaHoaDon))
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
            ViewData["Mp"] = new SelectList(_context.Phongs, "Mp", "KhuVuc", hoaDon.Mp);
            return View(hoaDon);
        }

        // GET: Admin/HoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HoaDons == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.MpNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: Admin/HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HoaDons == null)
            {
                return Problem("Entity set 'QlktxContext.HoaDons'  is null.");
            }
            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDons.Remove(hoaDon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
          return (_context.HoaDons?.Any(e => e.MaHoaDon == id)).GetValueOrDefault();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> InHoaDon(int id)
        {
            var hoaDon = await _context.HoaDons
                .Include(h => h.MpNavigation)
                .FirstOrDefaultAsync(m => m.MaHoaDon == id);

            ViewData["hoaDon"] = hoaDon;

            string duongDanThuMuc = @"D:\HoaDon\";
            if (!Directory.Exists(duongDanThuMuc))
            {
                Directory.CreateDirectory(duongDanThuMuc);
            }

            using (var stringWriter = new StringWriter())
            {
                var viewResult = _compositiveViewEngine.FindView(ControllerContext, "InHoaDon", false);

                if (viewResult.View == null)
                {
                    throw new ArgumentNullException("View không tồn tại");
                }

                var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
                viewDictionary["hoaDon"] = hoaDon;

                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    viewDictionary,
                    TempData,
                    stringWriter,
                    new HtmlHelperOptions());

                try
                {
                    await viewResult.View.RenderAsync(viewContext);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi render view: " + ex.Message);
                    throw; 
                }

                var htmlToPdf = new HtmlToPdf(1000, 1414);
                htmlToPdf.Options.DrawBackground = true;

                var pdf = htmlToPdf.ConvertHtmlString(stringWriter.ToString());
                var pdfBytes = pdf.Save();

                using (var streamWriter = new StreamWriter(@"D:\HoaDon\HoaDon_" + hoaDon.MaHoaDon + ".pdf"))
                {
                    await streamWriter.BaseStream.WriteAsync(pdfBytes, 0, pdfBytes.Length);
                }

                return File(pdfBytes, "application/pdf");

            }

        }



    }
}
