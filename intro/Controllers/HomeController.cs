using intro.Models;
using intro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace intro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RandomService _randomService;
        private readonly IHasher _hasher;
        private readonly IDateTime _dateTime;
        private readonly DAL.Context.IntroContext _introContext;
        public HomeController(ILogger<HomeController> logger,  //Создание зависимостей 
            RandomService randomService,                        //через конструктор
            IHasher hasher,
            IDateTime dateTime,
            DAL.Context.IntroContext introContext)
        {
            _logger = logger;
            _randomService = randomService;
            _hasher = hasher;
            _dateTime = dateTime;
            _introContext = introContext;
        }


        public IActionResult Index()
        {
            ViewData["rnd"] = _randomService.Integer;
            ViewBag.hash = _hasher.Hash("123");
            ViewData["dt"] = _dateTime.date("dd:mm:yyyy");
            ViewData["tm"] = _dateTime.time("HH:MM::SS");
            ViewData["UsersCount"] = _introContext.Users.Count();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            var model = new AboutModel
            {
                Data = "The Model Data"
            };
            return View(model);
        }

        public IActionResult Contacts()
        {
            var contacts = new ContactsModel
            {
                Address = "Pushkinskaya str, 19",
                PhoneNumber = "322-223",
                Name = "Rozetka LLC"
            };
            return View(contacts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
