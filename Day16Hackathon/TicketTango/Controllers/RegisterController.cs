using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketTango.Models;
using TicketTango.Service;

namespace TicketTango.Controllers
{
    public class RegisterController : Controller
    {
        readonly IUserService _userService;
        public RegisterController(IUserService userService)
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
        public async Task<IActionResult> Index(User user)
        {
            ModelState.Remove("TicketBookings");
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            int result = await _userService.Register(user);
            if (result > 0)
            {
                TempData["message"] = "Registration Done Successfully!";
                return Redirect("Login/Index");
            }
            else
            {
                TempData["message"] = "Registration Failed!";
                return View();
            }
        }
    }
}
