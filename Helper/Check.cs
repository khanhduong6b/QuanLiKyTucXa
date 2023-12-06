using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuanLiKyTucXa.Helper
{
    public class Check : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var u = context.HttpContext.Session.GetString("Username");
            if (u == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"Controller","Auth" },
                    {"Action", "Login" }
                });
            }
            else if (u != null)
            {
                var username = u.ToString().ToLower();
                var controller = context.RouteData.Values["controller"].ToString();
                var area = context.RouteData.Values["area"]?.ToString();
                if (area == "Admin" && username.StartsWith("dh"))
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"Controller","Home" },
                        {"Action", "Index" }
                    });
                    return; // Trả về kết quả để ngăn người dùng tiếp tục truy cập trang Admin
                }
                
            }
        }

    }
}
