using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.Entities.Orders;
using MyCrm.Domain.ViewModels.Actions;

namespace MyCrm.Domain.Entities.Tasks
{
    public class CrmTask
    {
        [Key]
        public long TaskId { get; set; }

        public long MarketerId { get; set; }
        public long? OrderId { get; set; }

        [Display(Name = "اولویت")]
        public int Priority { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ انجام تسک")]
        public DateTime UntilDate { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool IsDelete { get; set; } = false;
        public CrmTaskStatus TaskStatus { get; set; }



        #region Relations

        public Marketer Marketer { get; set; }
        public Order Order { get; set; }
        public ICollection<MarketingAction> MarketingActions { get; set; }

        #endregion
    }

    public enum CrmTaskStatus
    {
        [Display(Name = "درحال پیگیری")]
        Active,
        [Display(Name = "بسته شده")]
        Close,
        [Display(Name = "درحال انتظار")]
        Waiting
    }
}
