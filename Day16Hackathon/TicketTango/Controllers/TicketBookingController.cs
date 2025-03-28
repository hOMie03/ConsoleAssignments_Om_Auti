﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketTango.Filters;
using TicketTango.Models;
using TicketTango.Service;
using TicketTango.ViewModels;

namespace TicketTango.Controllers
{
    [ServiceFilter(typeof(ExceptionHandlerAttribute))]
    public class TicketBookingController : Controller
    {
        readonly IEventService _eventService;
        readonly ITicketBookingService _tbService;
        public TicketBookingController(IEventService eventService, ITicketBookingService tbService)
        {
            _eventService = eventService;
            _tbService = tbService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PaymentMethod()
        {
            TempData.Keep();
            return View();
        }

        public async Task<IActionResult> BookTicket(BookingViewModel model, int eventID, int quantity)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userId != null && userId > 0)
            {

                var bookMod = model;
                var eventDetails = await _eventService.GetEventByIdAsync(eventID);
                bookMod.TotalCost = eventDetails.TicketPrice * quantity;
                ViewBag.EventDetails = eventDetails;
                return View(bookMod);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpPost]
        public async Task<IActionResult> BookTicket(int userID, int eventID, int quantity)
        {

            int result = await _tbService.BookTicketAsync(userID, eventID, quantity);
            if (result > 0)
            {
                TempData["message"] = "Ticket has been booked successfully!";
                return RedirectToAction("PaymentMethod");
            }
            else
            {
                TempData["message"] = "Ticket Booking Failed!";
                return View();
            }
        }
        public async Task<IActionResult> GetBookingsByUserId(int userID)
        {
            try
            {
                var userTix = await _tbService.GetBookingsByUserIdAsync(userID);
                return View(userTix);
            }
            catch (ApplicationException ex)
            {
                TempData["emptyError"]= ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> CancelBooking(int id)
        {
            int? userID = HttpContext.Session.GetInt32("UserID");
            if (userID != null && userID > 0)
            {
                var eventResult = await _tbService.GetTixByUserAndBookingIdAsync((int)userID, id);
                return View(eventResult);
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public async Task<IActionResult> CancelBooking(int id, string name)
        {
            try
            {
                var userTix = await _tbService.CancelBookingAsync(id);
                TempData["message"] = "Your ticket has been deleted. Refund will be done in next 7 business days.";
                return RedirectToAction("Index", "Home");
            }
            catch (ApplicationException ex)
            {
                TempData["cancelError"] = ex.Message;
                return View();
            }
        }
    }
}
