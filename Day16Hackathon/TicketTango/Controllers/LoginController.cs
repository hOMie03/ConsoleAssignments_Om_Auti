﻿using Microsoft.AspNetCore.Mvc;
using TicketTango.Models;
using TicketTango.Service;
using TicketTango.ViewModels;

namespace TicketTango.Controllers
{
    public class LoginController : Controller
    {
        readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId != null && userId > 0)
            {
                return Redirect("Home/Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var loginCheck = await _userService.Login(user.Email, user.Password);
            if (loginCheck != null)
            {
                HttpContext.Session.SetInt32("UserID", loginCheck.ID);
                HttpContext.Session.SetString("UserRole",(string) loginCheck.Roles.ToString());
                if (HttpContext.Session.GetString("UserRole") == "Admin")
                    return RedirectToAction("Index", "Admin");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["message"] = "Invalid Email/Password";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserRole");
            TempData["LogoutMsg"] = "Logout Successfully!";
            return Redirect("/Home/Index");
        }
    }
}
