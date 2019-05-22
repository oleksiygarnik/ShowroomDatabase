using DatabaseCar.Data_Access_Layer.EFDataContext;
using DatabaseCar.Data_Access_Layer.Entities;
using DatabaseCar.Presentation_Access_Layer.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DatabaseCar.Controllers
{
    public class AuthController : Controller
    {
        private ShowroomContext db;

        public AuthController(ShowroomContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = await db.Employees.Include(u => u.EmploymentContract).ThenInclude(u => u.Position)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (employee != null)
                {
                    await Authenticate(employee); // аутентификация
                      
                    return RedirectToAction("Index", employee.EmploymentContract.Position.Name);
                }
                else
                {
                    ModelState.AddModelError("Email", "Некорректные логин и(или) пароль");
                }

            }

            return View(model);
        }


        private async Task Authenticate(Employee user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.EmploymentContract.Position.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

    }
}
