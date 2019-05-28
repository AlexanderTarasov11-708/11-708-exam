using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MealService.Models;
using Microsoft.AspNetCore.Hosting;

namespace MealService.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext _context;
        IHostingEnvironment _appEnvironment;

        public HomeController(MyDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
