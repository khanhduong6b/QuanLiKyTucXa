using Microsoft.AspNetCore.Mvc;
using QuanLiKyTucXa.Helper;

namespace QuanLiKyTucXa.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Check]
    [Route("/HomeAdmin/[action]")]
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
