using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyCrm.Application.Interfaces;
using MyCrm.Application.Security;
using MyCrm.Application.Static_Tools;
using MyCrm.Data.Repository;
using MyCrm.Domain.Entities.Companies;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Company;
using MyCrm.Domain.ViewModels.Paging;
using SixLabors.ImageSharp;

namespace MyCrm.Application.Services
{
    public class CompanyService : ICompanyService
    {
        #region ctor
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        public CompanyService(ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }
        #endregion

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

        public async Task<FilterCompanyViewModel> FilterCompany(FilterCompanyViewModel filter)
        {
            var query = await _companyRepository.GetCompanyQueryable();

            query = query.Where(a => !a.IsDelete);

            #region Filter

            if (!string.IsNullOrEmpty(filter.FilterCompanyName))
            {
                query = query.Where(a => EF.Functions.Like(a.Name, $"%{filter.FilterCompanyName}%"));
            }

            if (!string.IsNullOrEmpty(filter.FilterCompanyCode))
            {
                query = query.Where(a => EF.Functions.Like(a.Code, $"%{filter.FilterCompanyCode}%"));
            }

            #endregion

            #region paging

            var pager = Pager.build(filter.PageId, await query.CountAsync(), filter.TakeEntity,
                filter.HowManyShowPageafterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetEntity(allEntities).SetPaging(pager);
        }
        public async Task<bool> DeleteCompany(long companyId)
        {
           var company = await _companyRepository.GetCompanyById(companyId);  
            if (company != null)
            {
                return false;
            }
            company.IsDelete = true;
            await _companyRepository.UpdateCompany(company);
            await _companyRepository.SaveChange();

            return true;
        }

        public async Task<EditCompanyResult> EditCompany(EditCompanyViewModel companyViewModel)
        {
            var com = await _companyRepository.GetCompanyById(companyViewModel.Id);

            if (com == null)
            {
                return EditCompanyResult.Error;
            }
            //com. = companyViewModel.Id;
            com.Description = companyViewModel.Description;
            
            com.Address = companyViewModel.Address;
            com.City = companyViewModel.City;
            com.AgentName = companyViewModel.AgentName;
            com.Code = companyViewModel.Code;
            com.Description = companyViewModel.Description;
            com.Phone = companyViewModel.Phone;
            
            await _companyRepository.UpdateCompany(com);
            await _companyRepository.SaveChange();
            return EditCompanyResult.Success;
        }

        public async Task<EditCompanyViewModel> FillEditCompanyViewModel(long companyId)
        {
           var com = await _companyRepository.GetCompanyById(companyId);   
            if (com == null)
            {
                return null;
            }
            var user = await _companyRepository.GetCompanyById(companyId);
            if (user == null)
            {
                return null;
            }
            var res = new EditCompanyViewModel()
            {
               Id = com.CompanyId,
                Address = com.Address,
                City = com.City,
                AgentName = com.AgentName,
                Code = com.Code,
                Description = com.Description,
                Phone = com.Phone,
                CreateDate = DateTime.Now
            };
            return res;
        }
        public async Task<List<Company>> GetCompaniesList()
        {
           var com = await _companyRepository.GetCompanyQueryable();
            return com.ToList();
        }

        public async Task<EditCompanyViewModel> GetCompanyForEdit(long companyId)
        {
            var com = await _companyRepository.GetCompanyById(companyId);
            if (com == null)
            {
                return null;
            }
            var res = new EditCompanyViewModel()
            {
              //  CompanyId = companyId,
              Id = companyId,
                Description = com.Description,
                Address = com.Address,
                Name = com.Name,
                Code = com.Code,
                City = com.City,
                Phone = com.Phone,
                Reagent = com.Reagent,
             CreateDate = DateTime.Now
            };
            return res;
        }

        public async Task<bool> SelectCompanyForCustomer(long companyId, long customerId)
        {
            var customer = await _companyRepository.GetCompanyById(customerId);
            var company = await _companyRepository.GetCompanyById(companyId);

            if (customer == null || company == null)
            {
                return false;
            }

            customer.CompanyId = companyId;
            await _companyRepository.UpdateCompany(customer);
            await _companyRepository.SaveChange();

            return true;
        }
    }
}
