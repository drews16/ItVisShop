using ItVisShop.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using ItVisShop.Domain.Enum;
using ItVisShop.Service.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ItVisShop.Domain.ViewModels.Account;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace ItVisShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet]
        public IActionResult Login() => View("/Views/Account/_Login.cshtml");
        [HttpGet]
        public IActionResult Register() => View("/Views/Account/Register.cshtml");

        // Регистрация пользователя.
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var response = await _accountService.Register(model);

                if(response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", response.Description);
            }

            return View("/Views/Account/Register.cshtml", model);
        }

        // Вход в аккаунт.
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.Login(model);

                if(response.StatusCode == Domain.Enum.StatusCode.Ok)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(response.Data));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", response.Description);
            }

            return View("/Views/Account/_Login.cshtml", model);
        }

        // Ввыхода из аккаунта.
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
