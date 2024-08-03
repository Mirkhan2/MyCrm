﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Orders;
using MyCrm.Domain.ViewModels.Paging;

namespace MyCrm.Domain.ViewModels.Orders
{
    public class FilterOrderSelectedMarketer : BasePaging
    {
        public List<OrderSelectedMarketer> OrdersSelectedMarketer { get; set; }
        public string FilterMarketerName { get; set; }
        public string FilterCustomerName { get; set; }


        public FilterOrderSelectedMarketer SetEntity(List<OrderSelectedMarketer> ordersSelectedMarketer)
        {
            this.OrdersSelectedMarketer = ordersSelectedMarketer;
            return this;
        }

        public FilterOrderSelectedMarketer SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.SkipEntity = paging.SkipEntity;
            this.StartPage = paging.StartPage;
          //  this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.PageCount = paging.PageCount;
            this.TakeEntity = paging.TakeEntity;

            return this;
        }
    }
}