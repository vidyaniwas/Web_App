using Microsoft.AspNetCore.Mvc;

namespace Web_App.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Arts()
        {
            return View();
        }
        public IActionResult Commerce()
        {
            return View();
        }
        public IActionResult Science()
        {
            return View();
        }
    }
}
