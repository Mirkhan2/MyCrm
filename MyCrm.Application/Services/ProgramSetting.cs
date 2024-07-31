using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels;

namespace MyCrm.Application.Services
{
    public class ProgramSetting : IProgramSetting
    {
        #region ctor
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IOrderService _orderService;
        public ProgramSetting(IUserRepository userRepository , ICompanyRepository companyRepository, IOrderService orderService)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository; 
            _orderService = orderService;

        }
        #endregion

        public async Task<DashboardViewModel> FillDashboardViewModel(long userId)
        {
            var allUsers = await _userRepository.GetUserQueryable();
            var allCompany = await _companyRepository.GetCompanyQueryable();
           

            var result = new DashboardViewModel()
            {
                CustomerCount = allUsers.Count(a => a.Customer != null),
                CompanyCount = allCompany.Count(a => !a.IsDelete),
                MarketerCount = allUsers.Count(a => a.Marketer!= null),
                TodayCustomerCount = allUsers.Count( a => a.Customer != null && a.CreateDate.Day == DateTime.Now.Day),
             //   SelfUser = _userRepository.GetUserDetailById(userId),


            };
            return result;
        }
    }
}
