﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Domain.ViewModels.Company
{
    public class CreateCompanyViewModel
    {
       

        [Display(Name = "نام شرکت")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
    [Required(ErrorMessage = "این فیلد اجباری است")]
    public string Name { get; set; }

    [Display(Name = "کد شرکت")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
    public string Code { get; set; }

    [Display(Name = "شهر")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
    public string City { get; set; }

    [Display(Name = "تلفن شرکت")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
    [Required(ErrorMessage = "این فیلد اجباری است")]
    public string Phone { get; set; }

    [Display(Name = "معرف")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
    public string Reagent { get; set; }

    [Display(Name = "نماینده شرکت")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
    public string AgentName { get; set; }

    [Display(Name = "آدرس شرکت")]
    [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از بلاک {1} باشد")]
    public string Address { get; set; }

    [Display(Name = "توضیحات")]
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsDelete { get; set; }
}
public enum CreateCompanyResult
    { 
        Success, Error 
    }

}
