using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VirtualFair.Models;
using VirtualFair.Models.RegisterModels;

namespace VirtualFair.Controllers
{
    [Authorize (Roles="Admin, Super Admin")]
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;
        private IPasswordValidator<User> _pvalidator;
        private IPasswordHasher<User> _phasher;


        public AdminController(UserManager<User> userManager, IPasswordValidator<User> pvalidator, IPasswordHasher<User> phasher)
        {
            _userManager = userManager;
            _pvalidator = pvalidator;
            _phasher = phasher;
        }


        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterUser user)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User();
                newUser.UserName = user.Name;
                newUser.Email = user.Email;


                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
                }
            }
            return View(user);
        }
        [HttpPost]


        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded) return RedirectToAction("Index");
                else { foreach (var item in result.Errors) ModelState.AddModelError("", item.Description); }
            }
            else { ModelState.AddModelError("404", "Kullanıcı bulunamadı"); }
            return View("Index", _userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id, string password, string email)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View(user);
            }
            else
            {
                user.Email = email;

                IdentityResult validp = null;

                if (!string.IsNullOrEmpty(password))
                {
                    validp = await _pvalidator.ValidateAsync(_userManager, user, password);
                    if (validp.Succeeded)
                    {
                        user.PasswordHash = _phasher.HashPassword(user, password);
                    }else
                    {
                        foreach (var item in validp.Errors) ModelState.AddModelError("", item.Description);
                    }
                    if (validp.Succeeded)
                    {
                        var result = await _userManager.UpdateAsync(user);
                        if (result.Succeeded) return RedirectToAction("Index");
                        else foreach (var item in validp.Errors) ModelState.AddModelError("", item.Description);
                    }

                }
                else { ModelState.AddModelError("404", "Kullanıcı bulunamadı"); 
                }
                
            }
            return View(user);
        }
    }
}
