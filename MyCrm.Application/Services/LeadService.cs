using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
using MyCrm.Domains.Interfaces;
using MyCrm.Domains.ViewModels.Events;
using MyCrm.Domains.ViewModels.Leads;

namespace MyCrm.Application.Services
{
    public class LeadService : ILeadService
    {
        #region Ctor
        private readonly ILeadRepository _leadRepository;
        private readonly IUserRepository _userRepository;
        public LeadService(ILeadRepository leadRepository, IUserRepository userRepository)
        {
            _leadRepository = leadRepository;
            _userRepository = userRepository;
        }

        public Task<bool> ChangeLeadState(long leadId, int stateIndex)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CloseAndWinLead(long leadId)
        {
            throw new NotImplementedException();
        }

        public Task<CreateLeadResult> CreateLead(CreateLeadViewModel leadViewModel, long userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLead(long leadId)
        {
            throw new NotImplementedException();
        }

        public Task<EditLeadResult> EditLead(EditLeadViewModel leadViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<EditLeadViewModel> FillEditLeadViewModel(long leadId)
        {
            throw new NotImplementedException();
        }

        public Task<FilterLeadViewModel> FilterLeads(FilterLeadViewModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetLeadToMarketer(long leadId, long marketerId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
