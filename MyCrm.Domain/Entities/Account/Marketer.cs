﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Orders;
using MyCrm.Domain.Entities.Tasks;

namespace MyCrm.Domain.Entities.Account
{

    public class Marketer
    {
        [Key, ForeignKey("User")]
        public long UserId { get; set; }

        [Display(Name = "رشته تحصیلی")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string FieldStudy { get; set; }

        public int Age { get; set; }

        [Display(Name = "کد ملی")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string IrCode { get; set; }

        public Education Education { get; set; }

        public bool IsDelete { get; set; }


        #region Relations

        public User User { get; set; }
        public ICollection<OrderSelectedMarketer> OrderSelectedMarketers { get; set; }
        public ICollection<CrmTask> CrmTasks { get; set; }

        #endregion
    }

    public enum Education
    {
        [Display(Name = "دیپلم")]
        Diploma,
        [Display(Name = "لیسانس")]
        Bachelor,
        [Display(Name = "فوق لیسانس")]
        Master,
        [Display(Name = "دکترا")]
        PHD
    }

}
