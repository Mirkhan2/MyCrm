using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.Entities.Leads;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Lead;
using MyCrm.Domain.ViewModels.Leads;
using static MyCrm.Domain.ViewModels.Leads.CreateLeadViewModel;

namespace MyCrm.Application.Services
{
    public class LeadService : ILeadService
    {
        #region Ctor
        private readonly ILeadRepository _leadRepository;
        private readonly IUserRepository _userRepository;
        public LeadService(ILeadRepository leadRepository,IUserRepository userRepository )
        {
            _leadRepository = leadRepository;
            _userRepository = userRepository;
        }


        #endregion
        public async Task<CreateLeadViewModel.CreateLeadResult> CreateLead(CreateLeadViewModel leadViewModel,long userid)
        {
            var user = _userRepository.GetUserById(userid);
            if (user == null)
            {
                return CreateLeadResult.Error;
            }

            var lead = new Lead()
            {
                Company = leadViewModel.Company,
                CreatedById = userid,
                Description = leadViewModel.Description,
                Email = leadViewModel.Email,
                FirstName = leadViewModel.FirstName,
                LastName = leadViewModel.LastName,
                LeadStatus = LeadStatus.New,
                OwnerId = userid,
                Topic = leadViewModel.Topic,
                Mobile = leadViewModel.Mobile,
                IsWin = false
            };
            await _leadRepository.AddLead(lead);
            await _leadRepository.SaveChanges();

            return CreateLeadViewModel.CreateLeadResult.Success;
        }

        public Task<bool> DeleteLead(long leadId)
        {
            throw new NotImplementedException();
        }

        public Task<EditLeadViewModel.EditLeadResult> EditLead(EditLeadViewModel leadViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<EditLeadViewModel> FillEditViewModel(long leadId)
        {
            throw new NotImplementedException();
        }

        public Task<FilterLeadViewModel> FilterLead(FilterLeadViewModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<EditLeadViewModel> GetLeadForEdit(long leadId)
        {
            throw new NotImplementedException();
        }
    }
}
