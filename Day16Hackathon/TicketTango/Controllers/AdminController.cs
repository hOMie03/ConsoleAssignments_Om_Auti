using Microsoft.AspNetCore.Mvc;
using TicketTango.Service;

namespace TicketTango.Controllers
{
    public class AdminController : Controller
    {
        readonly IEventService _eventService;
        readonly IUserService _userService;
        public AdminController(IEventService eventService, IUserService userService)
        {
            _eventService = eventService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllEvents()
        {
            return View(await _eventService.GetAllEventsAsync());
        }

        public async Task<IActionResult> GetAllUsers()
        {
            return View(await _userService.GetAllUsersAsync());
        }

        public async Task<IActionResult> PromoteToEventOrg(int userID)
        {
            var promoted = await _userService.PromoteToEventOrgAsync(userID);
            if(promoted > 0)
            {
                TempData["promotionMsg"] = "Promoted to Event Organizer";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["promotionMsg"] = "Promotion Unsuccessful. Couldn't found the user";
                return View();
            }
        }
    }
}
