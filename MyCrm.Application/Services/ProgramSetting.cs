using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Application.Interfaces;
using MyCrm.Domains.Entities.Leads;
using MyCrm.Domains.Interfaces;
using MyCrm.Domains.ViewModels;

namespace MyCrm.Application.Services
{
    public class ProgramSetting : IProgramSetting
    {
        #region Ctor

        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ILeadRepository _leadRepository;

        public ProgramSetting(IUserRepository userRepository, ICompanyRepository companyRepository, IOrderRepository orderRepository, ILeadRepository leadRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _orderRepository = orderRepository;
            _leadRepository = leadRepository;
        }

        #endregion

        public async Task<DashboardViewModel> FillDashboardViewModel(long userId)
        {
            var allUsers = await _userRepository.GetUserQueryable();
            var allCompany = await _companyRepository.GetCompanyQueryable();

            var leadQueryable = await _leadRepository.GetLeadsQueryable();

            var orderPerMonth = new List<int>();

            var orderQueryable = await _orderRepository.GetOrders();

            orderQueryable = orderQueryable.Where(a => !a.IsDelete);

            for (int i = 0; i < 5; i++)
            {
                var ordersCount = orderQueryable.Count(a => a.CreateDate.Month == DateTime.Now.AddMonths(-i).Month);
                orderPerMonth.Add(ordersCount);
            }


            var result = new DashboardViewModel()
            {
                CustomerCount = allUsers.Count(a => a.Customer != null),
                CompanyCount = allCompany.Count(a => !a.IsDelete),
                MarketerCount = allUsers.Count(a => a.Marketer != null),
                TodayCustomerCount = allUsers.Count(a => a.Customer != null && a.CreateDate.Day == DateTime.Now.Day),
                SelfUser = await _userRepository.GetUserDetailById(userId),
                UserOpenLeadCount = leadQueryable.Count(a => a.OwnerId == userId && a.LeadStatus == LeadStatus.Active),
                OrderCountPerMonth = Enumerable.Reverse(orderPerMonth).ToList(),
            };

            return result;
        }
    }
}
