using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VirtualFair.Models;
using VirtualFair.Models.RegisterModels;

namespace VirtualFair.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
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
              

                var result = await _userManager.CreateAsync(newUser,user.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
                }
            }
            return View(user);
        }
    }
}
