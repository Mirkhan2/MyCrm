using System.Threading.Tasks;
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
        public async Task<IActionResult> EditEvent(long eventId)
        {
        var res= await _eventService.FillEditEventViewModel(eventId);
            if (res == null)
            {
                return NotFound();
            }
           //ViewBag.eventt= await _eventService.GetEventById(res.EventId);
           return View(res);
        }
        //[HttpGet]
        //public async Task<IActionResult> EditEvent(long id)
        //{
        //    var result = await _eventService.GetEventForEditEvent(id);
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(result);
        //}

        [HttpPost]
        public async Task<IActionResult> EditEvent(EditEventViewModel eventViewModel)
        {
          //  await _eventService.GetEventById(eventViewModel.EventId);
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage]= "";
                return View(eventViewModel);
            }

            var result = await _eventService.EditEvent(eventViewModel);
            switch (result)
            {
                case EditEventResult.Success:
                    TempData[SuccessMessage]= " ";
                    return RedirectToAction("FilterEvents");
                case EditEventResult.Error:
                    TempData[ErrorMessage]= " ";
                    break;
               
            }
            return View(eventViewModel);
        }
        #endregion

        #region Delete
        public async Task<IActionResult > DeleteEvent(long eventId)
        {
            var result = await _eventService.DeleteEvent(eventId);

            if (result)
            {
                TempData[SuccessMessage] = "";
                return RedirectToAction("FilterEvents");
            }

            else
            {
                TempData[ErrorMessage] = "";
                return RedirectToAction("FilterEvents");
            }
        }
        #endregion
    }
}
