using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Leads;

namespace MyCrm.Domains.Interfaces
{
    public interface ILeadRepository
    {
        Task AddLead(Lead lead);

        Task UpdateLead(Lead lead);

        Task SaveChanges();

        Task<Lead> GetLeadById(long leadId);

        Task<IQueryable<Lead>> GetLeadsQueryable();
    }
}
