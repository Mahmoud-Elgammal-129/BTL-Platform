﻿using BTL_Platform.Models;
using BTL_Platform.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTL_Platform.Controllers
{
    public class LoginController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly RoleManager<IdentityRole> _roleManager;


        public LoginController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,

            IWebHostEnvironment webHostEnvironment
,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {


            if (ModelState.IsValid)
            {
                var data = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (data.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    var userId = user.Id;
                    _httpContextAccessor.HttpContext.Session.SetString("UserId", userId);
                    if (user != null)
                    {
                        return RedirectToAction("Home", "Home");
                    }

                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");

            }

            return View(model);

        }
        public IActionResult RegisterEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email,
                    Name = model.UserName,
                    UserName = model.UserName,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "employee");
                    return RedirectToAction(nameof(Login));

                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return View(model);
        }
        public async Task<IActionResult> EditEmployee(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            var model = new EditVM
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName
                // Add other properties you want to edit here
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                user.Email = model.Email;
                user.UserName = model.UserName;
                // Update other properties you want to edit here

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(GetUsers));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<ActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login", "login");
        }
    }
}
