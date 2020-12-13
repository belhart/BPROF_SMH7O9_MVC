using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using F1Stats.Web.Models;
using F1Stats.Logic;

namespace F1Stats.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HomeViewModel vm;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.vm = new HomeViewModel();
            vm.TeamWithMostPoints = OsszetettLogic.GetTeamWithMostPoints();
            vm.ListOfSumPointResult = OsszetettLogic.GetDriversPoints().ToList();
            vm.ListOfEnginePointResult = OsszetettLogic.GetResultWithEngineNames(15).ToList();
        }

        public IActionResult Index()
        {
            return View("Index", vm);
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
