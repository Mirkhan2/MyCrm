﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Tasks;
using MyCrm.Domain.ViewModels.Paging;

namespace MyCrm.Domain.ViewModels.Tasks 
{
    public class FilterTaskViewModel : BasePaging
    {
        public List<CrmTask> CrmTasks { get; set; }
        public string FilterOrderName { get; set; }
        public string FilterCustomerName { get; set; }

        public FilterTaskViewModel SetEntity(List<CrmTask> tasks)
        {
            this.CrmTasks = tasks;
            return this;
        }
        public FilterTaskViewModel SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.SkipEntity  = paging.SkipEntity;
          this.HowManyShowPageafterAndBefore = paging.HowManyShowPageafterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this;
        }
    }

}