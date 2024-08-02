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

        public async  Task ILeadRepository.AddLead(Lead lead)
        {
            await _context.Leads.Add(lead);
        }

       public  async Task<Lead> ILeadRepository.GetLeadById(long leadId)
        {

            await _context.Leads.Update(lead);
        }

         Task<IQueryable<Lead>> ILeadRepository.GetLeadQueryable()
        {
            return  _context.Leads.AsQueryable();
        }

        async Task ILeadRepository.SaveChanges()
        {
            await _context.Leads.FirstOrDefaultAsync(a => a.LeadId == leadId);
        }

        Task ILeadRepository.UpdateLead(Lead lead)
        {
            throw new NotImplementedException();
        }
    }
}
