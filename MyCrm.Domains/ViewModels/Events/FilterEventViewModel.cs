using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Events;
using MyCrm.Domains.ViewModels.Paging;

namespace MyCrm.Domains.ViewModels.Events
{
    public class FilterEventViewModel : BasePaging
    {
        public List<Event> Events { get; set; }

        public string FilterTitle { get; set; }

        public string StartFromDate { get; set; }

        public string EndFromDate { get; set; }

        public FilterEventViewModel SetEntity(List<Event> events)
        {
            this.Events = events;
            return this;
        }

        public FilterEventViewModel SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.SkipEntity = paging.SkipEntity;
            this.StartPage = paging.StartPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this;
        }
    }
}
