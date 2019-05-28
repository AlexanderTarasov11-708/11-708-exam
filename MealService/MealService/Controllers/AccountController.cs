using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MealService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace MealService.Controllers
{
    public class AccountController : Controller
    {
        MyDbContext _context;
        IHostingEnvironment _appEnvironment;

        public AccountController(MyDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        
        public IActionResult Index()
        {
            if (_context.Roles.Count() == 0)
            {
                //добавляем роли
                var usr = new Role { Id = 0, Name = "user" };
                _context.Roles.Add(usr);
                usr = new Role { Id = 1, Name = "admin" };
                _context.Roles.Add(usr);
                
                //админ
                AddUser(new User { Login = "admin0", Role = usr, RoleId = 0 });
            }

            return View();
        }

        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            return RedirectToAction("Index", "Home");
        }
    }
}