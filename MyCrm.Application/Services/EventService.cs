using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyCrm.Application.Convertor;
using MyCrm.Application.Interfaces;
using MyCrm.Domains.Entities.Events;
using MyCrm.Domains.Interfaces;
using MyCrm.Domains.ViewModels.Events;
using MyCrm.Domains.ViewModels.Paging;

namespace MyCrm.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<AddEventResult> AddEvent(AddEventViewModel eventViewModel, long userId)
        {

            var newEvent = new Event()
            {
                Content = eventViewModel.Content,
                EventDate = eventViewModel.EventDate.ToMiladiDate(),
                EventType = eventViewModel.EventType,
                Title = eventViewModel.Title,
                UserId = userId
            };

            await _eventRepository.AddEvent(newEvent);
            await _eventRepository.SaveChange();

            return AddEventResult.Success;

        }
       
        public async Task<EditEventResult> EditEvent(EditEventViewModel eventViewModel)
        {
            var myEvent = await _eventRepository.GetEventById(eventViewModel.EventId);

            if (myEvent == null)
            {
                return EditEventResult.Fail;
            }

            myEvent.Content = eventViewModel.Content;
            myEvent.EventDate = eventViewModel.EventDate.ToMiladiDate();
            myEvent.EventType = eventViewModel.EventType;
            myEvent.Title = eventViewModel.Title;

            await _eventRepository.UpdateEvent(myEvent);
            await _eventRepository.SaveChange();

            return EditEventResult.Success;

        }

        public async Task<EditEventViewModel> FillEditEventViewModel(long eventId)
        {
            var myEvent = await _eventRepository.GetEventById(eventId);

            if (myEvent == null)
            {
                return null;
            }

            var result = new EditEventViewModel()
            {
                EventType = myEvent.EventType,
                Content = myEvent.Content,
                EventDate = myEvent.EventDate.ToShamsiDate(),
                Title = myEvent.Title,
                EventId = myEvent.EventId
            };

            return result;
        }

        public async Task<FilterEventViewModel> FilterEvents(FilterEventViewModel filter)
        {
            var query = await _eventRepository.GetEventsQueryAble();

            query = query.Where(a => !a.IsDelete);

            #region Filter

            if (!string.IsNullOrEmpty(filter.FilterTitle))
            {
                query = query.Where(a => EF.Functions.Like(a.Title, $"%{filter.FilterTitle}%"));
            }

            if (!string.IsNullOrEmpty(filter.StartFromDate))
            {
                query = query.Where(a => a.EventDate > filter.StartFromDate.ToMiladiDate());
            }

            if (!string.IsNullOrEmpty(filter.EndFromDate))
            {
                query = query.Where(a => a.EventDate < filter.EndFromDate.ToMiladiDate());
            }

            //if (!string.IsNullOrEmpty(filter.FilterCompanyCode))
            //{
            //    query = query.Where(a => EF.Functions.Like(a.Code, $"%{filter.FilterCompanyCode}%"));
            //}

            #endregion

            #region paging

            var pager = Pager.build(filter.PageId, await query.CountAsync(), filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetEntity(allEntities).SetPaging(pager);
        }
        public async Task<bool> DeleteEvent(long eventId)
        {
            var myEvent = await _eventRepository.GetEventById(eventId);

            if (myEvent == null)
            {
                return false;
            }

            myEvent.IsDelete = true;

            await _eventRepository.UpdateEvent(myEvent);
            await _eventRepository.SaveChange();

            return true;
        }


    }
}