using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TicketTango.Models;
using TicketTango.Service;

namespace TicketTango.Controllers
{
    public class HomeController : Controller
    {
        readonly IEventService _eventService;
        public HomeController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _eventService.GetAllEventsAsync());
        }

        public async Task<IActionResult> SearchEvent(string searched)
        {
            var events = await _eventService.SearchEventAsync(searched);
            return View(events);
        }
    }
}
