using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Tasks;

namespace MyCrm.Domain.ViewModels.Tasks
{
    public class CreateTaskViewModel
    {

        public long MarketerId { get; set; }
        public long? OrderId { get; set; }

        [Display(Name = "اولویت")]
        public int Priority { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ انجام تسک")]
        public DateTime UntilDate { get; set; }

        public CrmTaskStatus TaskStatus { get; set; }


    }
    public enum CreateTaskResult
    {
        Success,
        Fail
    }
}
