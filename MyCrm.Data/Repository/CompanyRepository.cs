using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Data.Context;
using MyCrm.Domain.Entities.Companies;
using MyCrm.Domain.Interfaces;

namespace MyCrm.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        #region Ctor

        private readonly CrmContext _context;
        public CompanyRepository(CrmContext context)
        {
            _context = context;
        }


        #endregion
        public async Task<Company> GetCompanyById(long companyId)
        {
            return null;
            return await _context.Companies.FirstOrDefaultAsync(a => a.CompanyId == companyId);
            //return await _context.FindAsync(companyId);
        }
        public async Task AddCompany(Company company)
        {
           await _context.Companies.AddAsync(company);
            
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompany(Company company)
        {
        _context.Companies.Update(company);
        }

        public async Task<IQueryable<Company>> GetCompanyQueryable()
        {
            return _context.Companies.AsQueryable();
        }

        //public Task DeleteCompany(long companyId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
