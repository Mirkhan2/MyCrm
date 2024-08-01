﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.ViewModels.Events;

namespace MyCrm.Web.Controllers
{
    public class EventController : BaseController
    {
        #region Ctor
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
            
        }
        #endregion

        #region Create Event
        public async Task<IActionResult> CreateEvent(AddEventViewModel eventViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "";
                return View(eventViewModel);

            }
            var result = await _eventService.AddEvent(eventViewModel, User.GetUserId());
            switch (result)
            {
                case AddEventResult.Success:
                    TempData[SuccessMessage] = "";
                    return RedirectToAction("CreateEvent");
                  
                case AddEventResult.Error:
                    TempData[ErrorMessage] = " ";
                    break;
               
            }
            return View(eventViewModel);

        }
        #endregion


        #region Filter Event
        public async Task<IActionResult> FilterEvents(FilterEventViewModel filter)
        {
            var result = await _eventService.FilterEvent(filter);
            return View(result);
        }
        //   public Task<IActionResult> FilterOrders(Filer)
        #endregion
        #region Edit
        public async Task<IActionResult> EditEvent(long event)
            {

        }
        #endregion
    }
}
