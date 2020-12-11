using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Config;
using Sample.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConfigManager _config;
        private readonly IWebHostEnvironment _host;

        public HomeController(ILogger<HomeController> logger,
            ConfigManager config,
            IWebHostEnvironment host)
        {
            _logger = logger;
            _config = config;
            _host = host;
        }

        public IActionResult Index()
        {
            ViewBag.AppId = _config.AppSettings.AppId;
            ViewBag.ContentRootPath = _host.ContentRootPath;
            ViewBag.WebRootPath = _host.WebRootPath;
            ViewBag.BaseDirectory = AppContext.BaseDirectory;
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
