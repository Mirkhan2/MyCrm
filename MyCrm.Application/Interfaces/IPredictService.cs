using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Account;

namespace MyCrm.Application.Interfaces
{
    public interface IPredictService
    {
        Task<bool> ProcessMarketerPredict();
        Task DeleteAllMarketerPredict();
        Task<Marketer> GetMarketerPredict();

    }
}
