using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Application.Interfaces;
using MyCrm.Application.Security;
using MyCrm.Application.Static_Tools;
using MyCrm.Domain.Entities.Companies;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Company;
using SixLabors.ImageSharp;

namespace MyCrm.Application.Services
{
    public class CompanyService : ICompanyService
    {
        #region ctor
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CreateCompanyResult> CreateCompany(CreateCompanyViewModel companyViewModel)
        {
            //var orderImage = "";

            //if (imageName?.Length > 0)
            //{
            //    orderImage = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imageName.FileName);
            //    imageName.AddImageToServer(orderImage, FilePath.OrderImagePathServer, 280, 280);
            //}
            var company = new Company()
            {
                Name = companyViewModel.Name,
                Address = companyViewModel.Address,
                AgentName = companyViewModel.AgentName,
                City = companyViewModel.City,
                Code = companyViewModel.Code,
                Phone = companyViewModel.Phone,
                Reagent = companyViewModel.Reagent,
                CreateDate = DateTime.Now,

            };
            //if (!string.IsNullOrEmpty())
            //{

            //}
            await _companyRepository.AddCompany(company);
            await _companyRepository.SaveChange();

            return CreateCompanyResult.Success;
        }
        #endregion
    }
}
