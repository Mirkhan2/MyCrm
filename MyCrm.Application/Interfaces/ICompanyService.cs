using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Domain.Entities.Companies;
using MyCrm.Domain.ViewModels.Company;

namespace MyCrm.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<CreateCompanyResult> CreateCompany(CreateCompanyViewModel companyViewModel);
        Task<FilterCompanyViewModel> FilterCompany(FilterCompanyViewModel filter);
        Task<EditCompanyViewModel> GetCompanyForEdit(long companyId);
        Task<EditCompanyViewModel> FillEditCompanyViewModel(long companyId);

        Task<EditCompanyResult> EditCompany(EditCompanyViewModel companyViewModel);
        Task<bool> DeleteCompany(long companyId);


        Task<List<Company>> GetCompaniesList();
        Task<bool> SelectCompanyForCustomer(long companyId, long customerId);

    }
}
