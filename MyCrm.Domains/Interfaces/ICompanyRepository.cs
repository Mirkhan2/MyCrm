using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Companies;

namespace MyCrm.Domains.Interfaces
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(long companyId);
        Task AddCompany(Company company);
        Task UpdateCompany(Company company);
        Task SaveChange();
        Task<IQueryable<Company>> GetCompanyQueryable();
        // Task DeleteCompany(long companyId);

    }
}
