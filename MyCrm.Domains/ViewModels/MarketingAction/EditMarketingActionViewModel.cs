using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Domains.ViewModels.MarketingAction
{
    public class EditMarketingActionViewModel
    {

        public long ActionId { get; set; }
        public long CrmTaskId { get; set; }
        public string Description { get; set; }


    }
    public enum EditMarketingActionResult
    {
        Success, Fail
    }

}
