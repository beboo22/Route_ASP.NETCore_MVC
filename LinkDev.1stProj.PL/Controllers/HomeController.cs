using LinkDev._1stProj.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LinkDev._1stProj.BLL.Services.DepartmentServ;
using Microsoft.AspNetCore.Authorization;

namespace LinkDev._1stProj.PL.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicesDepartment _ServDep;

        public HomeController(ILogger<HomeController> logger , IServicesDepartment services  )
        {
            _logger = logger;
            _ServDep = services;
        }

        public IActionResult Index()
        {
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
