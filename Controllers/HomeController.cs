using System.Diagnostics;
using LibraryManagementSystemForPatika.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystemForPatika.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}