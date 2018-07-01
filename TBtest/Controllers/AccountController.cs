using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBtest.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TBtest.Controllers
{
        public class AccountController : Controller
        {
            private Models.TbContext _db;
            public AccountController(Models.TbContext context)
            {
                _db = context;
            }

            [HttpGet]
            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                    {
               
                    await Authenticate(model.Email); // 

                        return RedirectToAction("Projects", "Home" );
                    }
                    ModelState.AddModelError("", "wrong password or login");
                }
                return View(model);
            }

            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterModel model)
            {
                if (ModelState.IsValid)
                {
                    User user = await _db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    if (user == null)
                    {
                    // add user in database
                        var tempContact = new Contact {};
                        _db.Contacts.Add(tempContact);
                        var tempUser = new User { Email = model.Email, Password = model.Password, ContactId = tempContact.ContactId };
                        _db.Users.Add(tempUser);

                        await _db.SaveChangesAsync();

                        await Authenticate(model.Email); // auth

                        return RedirectToAction("Projects", "Home");
                    }
                    else
                        ModelState.AddModelError("", "wrong password or login");
                }
                return View(model);
            }

            private async Task Authenticate(string userName)
            {
                // создаем один claim
                var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
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
        }
    }