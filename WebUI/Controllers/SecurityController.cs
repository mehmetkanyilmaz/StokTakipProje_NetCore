using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private IUserService _userService;
        public SecurityController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            //HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            var result = _userService.Login(user.code, user.password);
            if (result.Success)//Kayıtlı kullanıcı var ise oturum açar.
            {
                //Kullanıcının bütün bilgileri
                var data = JsonConvert.SerializeObject(result.Data);

                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.UserData, data));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.id.ToString()));

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = result.Message;
            return View();
        }
    }
}
