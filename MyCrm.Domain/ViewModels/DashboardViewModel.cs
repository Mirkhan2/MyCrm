using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCrm.Domain.ViewModels
{
    public class DashboardViewModel
    {
        public int CustomerCount { get; set; }
        public int MarketerCount { get; set; }
        public int TodayCustomerCount { get; set; }
        public int CompanyCount { get; set; }
        public Entities.Account.User SelfUser { get; set; }
        public int UserOpenLeadCount { get; set; }
        public List<int> OrderCountPerMonth { get; set; }
    }
}
