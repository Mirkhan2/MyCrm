using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.ViewModels.Paging;

namespace MyCrm.Domain.ViewModels.Events
{
    public class FilterEventViewModel : BasePaging
    {
        public string FilterEventName { get; set; }
        public string FilterUserName { get; set; }
        public string MyProperty { get; set; }

        public List<Entities.Events.Event> Events { get; set; }
        public FilterEventViewModel SetEntity(List<Entities.Events.Event> events)
        {
            this.Events = events;
            return this;
        }
        public FilterEventViewModel SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.SkipEntity = paging.SkipEntity;
            this.TakeEntity = paging.TakeEntity;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.EndPage = paging.EndPage;
            this.StartPage = paging.StartPage;
            this.HowManyShowPageafterAndBefore = paging.HowManyShowPageafterAndBefore;
            this.PageCount = paging.PageCount;
            
            return this;

        }
    }
}
