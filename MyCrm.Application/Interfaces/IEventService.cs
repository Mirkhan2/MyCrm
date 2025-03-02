using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Domains.Entities.Events;
using MyCrm.Domains.ViewModels.Events;

namespace MyCrm.Application.Interfaces
{
    public interface IEventService
    {
        Task<AddEventResult> AddEvent(AddEventViewModel eventViewModel, long userId);

        Task<EditEventResult> EditEvent(EditEventViewModel eventViewModel);

        Task<EditEventViewModel> FillEditEventViewModel(long eventId);

        Task<FilterEventViewModel> FilterEvents(FilterEventViewModel filter);

        Task<bool> DeleteEvent(long eventId);
    }
}
