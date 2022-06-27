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
            ViewBag.RealName = _introContext.Users.Select(x => x.RealName).ToList();
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

        public ViewResult Register()
        {

            return View();
        }

        [HttpPost]
       
        public IActionResult RegUser(Models.RegUserModel UserData)
        {
            //return Json(UserData); способ проверить передачу данных
            String [] err = new String[6];
            if (UserData == null)
            {
                err[0] = ("Нет данных");
            }
            else {
                if (String.IsNullOrEmpty(UserData.RealName))
                {
                    err[1] = ("Имя не может быть пустым");
                }
                if (String.IsNullOrEmpty(UserData.Login))
                {
                    err[2] = ("Логин не может быть пустым");
                }
                if (String.IsNullOrEmpty(UserData.Email))
                {
                    err[5] = ("Email не может быть пустым");
                }
                if (String.IsNullOrEmpty(UserData.Password1))
                {
                    err[3] = ("Пароль не может быть пустым");
                }
                if (UserData.Password1 != UserData.Password2)
                {
                    err[4] = ("Пароль должен совпадать");
                }
            }
            UserData.Equals(err);
            ViewData["err"] = err;
            return View("Register");
        }
    
        public IActionResult Data()
        {
            return Json(new { field = "value" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
