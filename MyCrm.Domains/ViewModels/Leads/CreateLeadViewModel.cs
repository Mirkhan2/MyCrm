﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Domains.ViewModels.Leads
{
    public class CreateLeadViewModel
    {
        [Display(Name = "عنوان")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string Topic { get; set; }

        [Display(Name = "نام")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string LastName { get; set; }

        [Display(Name = "شرکت")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string Company { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string Email { get; set; }

        [Display(Name = "تلفن")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
        public string Mobile { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }

    public enum CreateLeadResult
    {
        Success,
        Fail
    }
}