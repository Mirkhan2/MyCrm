using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Domain.ViewModels.Company;

namespace MyCrm.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<CreateCompanyResult> CreateCompany(CreateCompanyViewModel companyViewModel);

    }
}
