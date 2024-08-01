using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyCrm.Application.Convertor;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interfaces;
using MyCrm.Application.Security;
using MyCrm.Application.Static_Tools;
using MyCrm.Data.Repository;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.Entities.Events;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Events;
using MyCrm.Domain.ViewModels.Paging;

namespace MyCrm.Application.Services
{
    public class EventService : IEventService
    {
        #region ctor

        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        #endregion

        public async Task<AddEventResult> AddEvent(AddEventViewModel eventr, long userId)
        {

            var eve = new Event()
            {
                //UserId = eventr.UserId,
                Content = eventr.Content,
                EventDate = eventr.EventDate.ToMiladiDate(),
                CreateDate = eventr.CreateDate,
                //EventId = eventr.EventId,
                EventType = eventr.EventType,
                Title = eventr.Title,
                UserId = userId


                //  IsDelete = eve.IsDelete,
                //User = eve.User

            };

            //if (!string.IsNullOrEmpty(imageProfileName))
            //{

            //}
            await _eventRepository.AddEvent(eve);
            await _eventRepository.SaveChange();

            return AddEventResult.Success;

        }

        public async Task<bool> DeleteEvent(long eventId)
        {
            var eve = await _eventRepository.GetEventById(eventId);
            if (eve == null)
            {
                return false;
            }
            eve.IsDelete = true;
            await _eventRepository.UpdateEvent(eve);
            await _eventRepository.SaveChange();

            return true;
        }

        public async Task<EditEventResult> EditEvent(EditEventViewModel eventr)
        {
            var eve = await _eventRepository.GetEventById(eventr.EventId);
            if (eve == null)
            {
                return EditEventResult.Error;
            }


            eve.Content = eventr.Content;
            eve.EventDate = eventr.EventDate.ToMiladiDate();
            // eve.CreateDate = eventr.CreateDate;
            //EventId = eventr.EventId,
            eve.EventType = eventr.EventType;
            eve.Title = eventr.Title;


            //eve.CreateDate = DateTime.Now.AddDays
            await _eventRepository.UpdateEvent(eve);
            await _eventRepository.SaveChange();
            return EditEventResult.Success;

        }

        public async Task<EditEventViewModel> FillEditEventViewMode(long eventId)
        {
            var myEvent = await _eventRepository.GetEventById(eventId);
            if (myEvent == null)
            {
                return null;
            }
            var result = new EditEventViewModel()
            {
                EventType = myEvent.EventType,
                Title = myEvent.Title,
                Content = myEvent.Content,
                EventDate = myEvent.EventDate.ToShamsiDate(),
                EventId = eventId

            };
            return result;
        }

        public async Task<FilterEventViewModel> FilterEvent(FilterEventViewModel filter)
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
                filter.HowManyShowPageafterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetEntity(allEntities).SetPaging(pager);
        }

        public Task<Event> GetEventById(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<EditEventViewModel> GetEventForEdit(long enventrId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEventList()
        {
            throw new NotImplementedException();
        }


    }
}
