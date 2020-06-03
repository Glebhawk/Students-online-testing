using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentsTesting1.Pages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using StudentsTesting1.Logic.Accounts;
using System.Text;
using System.Security.Cryptography;
using StudentsTesting1.IoC;
using StudentsTesting1.DataAccess;

namespace StudentsTesting1.Controllers
{
    public class AccountController : Controller
    {
        private IDBAccess dBAccess { get; set; }
        private AccountAccess accountAccess { get; set; }
        private IoCContainer IoC = new IoCContainer();

        public AccountController()
        {
            IoC.RegisterObject<IDBAccess, DBAccess>();
            accountAccess = new AccountAccess(dBAccess);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
        //        if (user == null)
        //        {
        //            // добавляем пользователя в бд
        //            user = new User { Email = model.Email, Password = model.Password };
        //            Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "user");
        //            if (userRole != null)
        //                user.Role = userRole;

        //            _context.Users.Add(user);
        //            await _context.SaveChangesAsync();

        //            await Authenticate(user); // аутентификация

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //    }
        //    return View(model);
        //}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(IndexModel model)
        {
            if (ModelState.IsValid)
            {
                var sha1 = new SHA1CryptoServiceProvider();
                var data = Encoding.UTF8.GetBytes(model.password);
                Account account = accountAccess.TryToLogin(model.login, Encoding.UTF8.GetString(sha1.ComputeHash(data)));
                if (account != null)
                {
                    await Authenticate(account);
                }
                ModelState.AddModelError("", "Неправильний логін або пароль!");

                model.login = Encoding.UTF8.GetString(sha1.ComputeHash(data));
            }
            return View(model);
        }

        private async Task Authenticate(Account account)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim("ID", account.ID.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, account.login),
            new Claim(ClaimsIdentity.DefaultRoleClaimType, account.role),
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
