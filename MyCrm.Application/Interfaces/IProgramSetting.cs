using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.ViewModels;

namespace MyCrm.Application.Interfaces
{
    public interface IProgramSetting
    {
        Task<DashboardViewModel> FillDashboardViewModel(long userId);
    }
}
