using Microsoft.AspNetCore.Mvc;
using TicketTango.Filters;
using TicketTango.Models;
using TicketTango.Service;

namespace TicketTango.Controllers
{
    [ServiceFilter(typeof(ExceptionHandlerAttribute))]
    public class EventController : Controller
    {
        readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [ServiceFilter(typeof(userAuthorizeFilter))]
        public async Task<IActionResult> Index()
        {
            return View(await _eventService.GetAllEventsAsync());
        }

        //[ServiceFilter(typeof(userAuthorizeFilter))]
        public async Task<IActionResult> GetEventByID(int id)
        {
            //try
            //{
                var eventResult = await _eventService.GetEventByIdAsync(id);
                return View(eventResult);
            //}
            //catch (ApplicationException ex)
            //{
            //    return Content(ex.Message);
            //}
        }

        [ServiceFilter(typeof(userAuthorizeFilter))]
        public IActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent(Event eventEntity)
        {
            ModelState.Remove("TicketBookings");
            if (!ModelState.IsValid)
            {
                return View(eventEntity);
            }
            int result = await _eventService.AddEventAsync(eventEntity);
            if (result > 0)
            {
                TempData["message"] = "Event Added Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Event Addition Failed!";
                return View(eventEntity);
            }
        }

        [ServiceFilter(typeof(userAuthorizeFilter))]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var eventResult = await _eventService.GetEventByIdAsync(id);
            return View(eventResult);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEvent(Event eventEntity)
        {
            int result = await _eventService.UpdateEventAsync(eventEntity);
            if (result > 0)
            {
                TempData["message"] = "Event Updated Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Event Updation Failed!";
                return View();
            }
        }

        [ServiceFilter(typeof(userAuthorizeFilter))]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var eventResult = await _eventService.GetEventByIdAsync(id);
            return View(eventResult);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEvent(int id, string name)
        {
            int result = await _eventService.DeleteEventAsync(id);
            if (result > 0)
            {
                TempData["message"] = "Event Deleted Successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Event Deletion Failed!";
                return View();
            }
        }

    }
}
