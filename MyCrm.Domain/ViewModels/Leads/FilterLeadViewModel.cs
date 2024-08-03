using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Leads;
using MyCrm.Domain.Entities.Orders;
using MyCrm.Domain.ViewModels.Orders;
using MyCrm.Domain.ViewModels.Paging;

namespace MyCrm.Domain.ViewModels.Leads
{
    public class FilterLeadViewModel : BasePaging
    {
        public List<Lead> Leads { get; set; }
        public string FilterLeadTopic { get; set; }
        public string FilterCustomerName { get; set; }
        public string FilterLeadName { get; set; }
        public FilterLeadState FilterLeadState { get; set; }
       


        public FilterLeadViewModel SetEntity(List<Lead> leads)
        {
            this.Leads = leads;
            return this;
        }

        public FilterLeadViewModel SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.SkipEntity = paging.SkipEntity;
            this.StartPage = paging.StartPage;
            this.HowManyShowPageafterAndBefore = paging.HowManyShowPageafterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this;
        }
    }

    public enum FilterLeadState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "درحال پیگیری")]
        Active,
        [Display(Name = "بسته شده")]
        Close,
        [Display(Name = "جدید")]
        New,
    }
}
