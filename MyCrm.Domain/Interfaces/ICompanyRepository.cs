using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Companies;
using MyCrm.Domain.ViewModels.Orders;

namespace MyCrm.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(long companyId);
        Task AddCompany(Company company);
        Task UpdateCompany(Company company);    
        Task SaveChange();

    }
}
