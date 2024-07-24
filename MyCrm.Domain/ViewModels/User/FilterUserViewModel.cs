using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.ViewModels.Paging;

namespace MyCrm.Domain.ViewModels.User
{
    public class FilterUserViewModel :BasePaging
    {
        public string FilterMobile { get; set; }
        public string FilterFirstName { get; set; }
        public string FilterLastName { get; set; }
        public List<Entities.Account.User> Users { get; set; }
   
            public FilterUserViewModel SetEntity(List<Entities.Account.User> users)
        {
            this.Users = users;
            return this;

        }
        public FilterUserViewModel SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            AllEntitiesCount = paging.AllEntitiesCount;
            this.SkipEntity = paging.SkipEntity;
            this.StartPage = paging.StartPage;
            this.HowManyShowPageafterAndBefore = paging.HowManyShowPageafterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this; 
        }
    }
}
