using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Domain.Entities.Events;
using MyCrm.Domain.ViewModels.Events;

namespace MyCrm.Application.Interfaces
{
    public interface IEventService
    {
        Task<AddEventResult> AddEvent(AddEventViewModel eventViewModel, long userId);
        Task<EditEventResult> EditEvent(EditEventViewModel eventViewModel);
        Task<FilterEventViewModel> FilterEvent(FilterEventViewModel filter);
     //   Task<EditEventViewModel> GetEventForEdit(long enventrId);
        Task<bool> DeleteEvent(long eventId);
      //  Task<Event> GetEventById(string userName);
      //  Task<List<Event>> GetEventList();
        Task<EditEventViewModel> FillEditEventViewModel(long  eventId);  

    }
}
