using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Controllers
{
    public class HomeController : Controller
    {
        //private readonly AppDbContext db;

        public HomeController(AppDbContext db)
        {
            //this.db = db;
        }

        //отображение поля ввода данных для поиска
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //отображение информации о проекте
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
