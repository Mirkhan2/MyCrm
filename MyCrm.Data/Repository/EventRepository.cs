using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Data.Context;
using MyCrm.Domain.Entities.Events;
using MyCrm.Domain.Interfaces;

namespace MyCrm.Data.Repository
{
    public class EventRepository : IEventRepository
    {
        #region ctor
        private readonly CrmContext _context;
        public EventRepository(CrmContext context)
        {
            _context = context;
        }
        #endregion
        public async Task AddEvent(Event myEvent)
        {
            await _context.Events.AddAsync(myEvent);
        }

        public async Task<Event> GetEventById(long eventId)
        {
            return await _context.Events.FindAsync(eventId);
        }

        public async Task<IQueryable<Event>> GetEventsQueryAble()
        {

             return  _context.Events.AsQueryable();
        
        }

        public async Task SaveChange()
        {
              await _context.SaveChangesAsync();
        }

        public async Task UpdateEvent(Event myEvent)
        {
             _context.Events.Update(myEvent);
        }
     
    }
}
