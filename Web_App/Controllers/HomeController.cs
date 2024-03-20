using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_App.Models;

namespace Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login( int Id)
        {
            int id = Id;
           

            switch (id)
            {
                case 1:
                    ViewBag.LoginTitle = "Admin";
                    break;
                case 2:
                    ViewBag.LoginTitle = "Student";
                    break;
                case 3:
                    ViewBag.LoginTitle = "Faculty";
                    break;
                
                default:
                    ViewBag.LoginTitle = null;
                    break;
            }

           



            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {

            return View();
        }
        [HttpGet]
        public IActionResult Notices()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Example()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
