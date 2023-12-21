using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLiKyTucXa.Models;

namespace QuanLiKyTucXa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Analysis/[action]")]
    public class AnalysisController : Controller
    {
        private readonly QlktxContext _context;

        public AnalysisController(QlktxContext context)
        {
            _context = context;
        }
        // GET: AnalysisController
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

        [HttpGet]
        public async Task<IActionResult> ThongKeSinhVienTheoNgayVao(DateTime ngayVao)
        {
            DateTime startDate = new DateTime(ngayVao.Year, ngayVao.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
             
            var sinhViens = await _context.PhieuDangKies
                .Where(pdk => pdk.NgayVao >= startDate && pdk.NgayVao <= endDate)
                .Select(pdk => pdk.MssvNavigation)
                .Distinct()
                .ToListAsync();

            return PartialView("_DanhSachSinhVienPartial", sinhViens);
        }


        [HttpGet]
        public async Task<IActionResult> ThongKePhongDaThanhToan()
        {
            // Lấy danh sách các phòng đã thanh toán
            var phongsDaThanhToan = await _context.HoaDons
                .Where(hd => hd.TrangThai == 1) // Chỉ lấy các hóa đơn đã thanh toán
                .Select(hd => hd.MpNavigation)
                .Distinct()
                .ToListAsync();

            return PartialView("_DanhSachPhongPartial", phongsDaThanhToan);
        }

    }
}
