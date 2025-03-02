using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Events;

namespace MyCrm.Domains.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> GetEventById(long eventId);
        Task<IQueryable<Event>> GetEventsQueryAble();
        Task AddEvent(Event myEvent);
        Task UpdateEvent(Event myEvent);
        Task SaveChange();

    }
}
