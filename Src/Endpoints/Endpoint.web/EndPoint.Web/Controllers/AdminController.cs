using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index( )
        {
            return View();
        }
      
    }
}
