using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualFair.Models;
using VirtualFair.Models.RegisterModels;

namespace VirtualFair.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _usermanager;
        private SignInManager<User> _signinmanager;

        public AccountController(UserManager<User> usermanager, SignInManager<User> signinmanager)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _usermanager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signinmanager.SignOutAsync();
                    var result = await _signinmanager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Email", "E-Posta ya da Parola Geçersiz!");
            }
            
            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            var user = _signinmanager.GetExternalLoginInfoAsync();
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
           
        }
       
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User();
                newUser.UserName = user.Name;
                newUser.Email = user.Email;


                var result = await _usermanager.CreateAsync(newUser, user.Password);
                if (result.Succeeded) {
                    await _signinmanager.SignOutAsync();
                    var result2 = await _signinmanager.PasswordSignInAsync(user.Name, user.Password, false, false);
                    if (result2.Succeeded)
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
                }
            }
            return View(user);
        }
    }
}
