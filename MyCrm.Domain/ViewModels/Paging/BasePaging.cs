using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Domain.ViewModels.Paging
{
    public class BasePaging
    {
        public int PageId { get; set; }
        public int PageCount { get; set; }
        public int AllEntitiesCount { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int TakeEntity { get; set; }
        public int SkipEntity { get; set; }
        public int HowManyShowPageafterAndBefore { get; set; }

    }
}
