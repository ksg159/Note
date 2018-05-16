using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Note.BLL;
using Note.DAL;
using Note.Model;
using Note.ViewModel;

namespace Note.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserBll _userBll;

        public AccountController(UserBll userBll)
        {
            _userBll = userBll;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {

            if (ModelState.IsValid)
            {
                if (_userBll.SaveUser(model))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userBll.GetUser(model);
                await CreateCookieAsync(user);

                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public async Task CreateCookieAsync(User user)
        {
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserId),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

            var claimsIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIndentity));
        }

        [HttpPost, Route("Account/Idvalid")]
        public IActionResult IdValidation(string idText)
        {
            if (_userBll.GetUser(idText))
            {
                return Ok(new { success = true }); 
            } else
            {
                return Ok(new { success = false });
            }
        }
    }
}