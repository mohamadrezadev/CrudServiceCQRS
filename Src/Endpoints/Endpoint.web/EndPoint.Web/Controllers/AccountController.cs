using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Web.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
            
        }
        public IActionResult login( )
        {
            return View();
        }
        public IActionResult signup( )
        {
            return View();
        }
    }
}
