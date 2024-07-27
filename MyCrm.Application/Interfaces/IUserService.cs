﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.ViewModels.User;
using static MyCrm.Domain.ViewModels.User.AddCustomerViewModel;

namespace MyCrm.Application.Interface
{
    public interface IUserService
    {
        Task<AddMarketerResult> AddMarketer(AddMarketerViewModel marketer, IFormFile imageProfile);
        Task<FilterUserViewModel> FilterUser(FilterUserViewModel filter);
        Task<EditMarketerViewModel> GetMarketerForEdit(long marketerId);
        Task<EditMarketerResult> EditMarketer(EditMarketerViewModel marketer, IFormFile imageProfile);

        Task<AddCustomerResult> AddCustomer(AddCustomerViewModel customerViewModel, IFormFile imageProfile);
        Task<EditCustomerViewModel> FillEditCustomerViewModel(long userId);

        Task<EditCustomerResult> EditCustomer(EditCustomerViewModel customerViewModel, IFormFile imageProfile);

        Task<bool> DeleteUser(long userId);
        Task<Customer> GetCustomerById(long customerId);
       

    }
}
