using Microsoft.AspNetCore.Mvc;
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
                return Redirect("Home/Index");
            }
            else
            {
                TempData["ErrorMsg"] = "Invalid Email/Password";
                return RedirectToAction("Index");
            }
        }
    }
}
