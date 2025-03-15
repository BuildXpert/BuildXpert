using Microsoft.AspNetCore.Mvc;

namespace BX.Backend.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
