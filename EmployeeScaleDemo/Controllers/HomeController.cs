using EmployeeScaleDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeScaleDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MachineName = Environment.MachineName;
            ViewBag.ProcessorCount = Environment.ProcessorCount;

            using (var process = Process.GetCurrentProcess())
            {
                ViewBag.MemoryMB =
                    Math.Round(process.WorkingSet64 / 1024.0 / 1024.0, 2);
            }

            return View();
        }

        public IActionResult Privacy()
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
