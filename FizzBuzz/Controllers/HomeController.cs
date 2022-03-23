using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Interfaces;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFizzBuzzService _service;

        public HomeController(ILogger<HomeController> logger, IFizzBuzzService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new FizzBuzzModel());
        }

        [HttpPost]
        public IActionResult Index(FizzBuzzModel  model)
        {
            if (!ModelState.IsValid) return Index();
            var inputArray = model.InputValues.Split(',');
            model.Result = _service.Run(inputArray);
            return View(model);
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
