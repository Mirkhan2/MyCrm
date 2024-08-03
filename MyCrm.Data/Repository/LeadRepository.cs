using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Data.Context;
using MyCrm.Domain.Entities.Leads;
using MyCrm.Domain.Interfaces;

namespace MyCrm.Data.Repository
{
    public class LeadRepository : ILeadRepository
    {
        #region ctor
        private readonly CrmContext _context;
        public LeadRepository(CrmContext context)
        {
            _context = context;
        }
        #endregion
        public async Task AddLead(Lead lead)
        {
            await _context.Leads.AddAsync(lead);
        }

        public async Task<Lead> GetLeadById(long leadId)
        {
           return await _context.Leads.FirstOrDefaultAsync(a => a.LeadId == leadId);  
        }

        public async Task<IQueryable<Lead>> GetLeadQueryable()
        {
            return  _context.Leads.AsQueryable();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLead(Lead lead)
        {
             _context.Leads.Update(lead);
        }
     


    }
}
