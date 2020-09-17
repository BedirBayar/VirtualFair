using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VirtualFair.Models;
using Microsoft.AspNetCore.Authorization;

namespace VirtualFair.Controllers
{
    [Authorize("Super Admin")]
    public class AdminRoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public AdminRoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded) return RedirectToAction("Index");
                else foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
            }
            return View(name);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            var members = new List<User>();
            var nonMembers = new List<User>();

            foreach(var item in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(item, role.Name)) members.Add(item);
                else nonMembers.Add(item);

                
            }
            var model = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(model); 
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {

               if(model.IdsToAdd!=null) foreach(var userId in model.IdsToAdd) { 
                var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if(!result.Succeeded) foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
                    }
                   
                }
                if(model.IdsToDelete!=null)foreach (var userId in model.IdsToDelete)
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded) foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
                    }

                }
            }
            return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded) return RedirectToAction("Index");
                else foreach (var item in result.Errors) ModelState.AddModelError("", item.Description);
            }
            ModelState.AddModelError("404", "Rol Silinirken Bir Hata Oluştu");
            return RedirectToAction("Index");

        } 
    }
}
