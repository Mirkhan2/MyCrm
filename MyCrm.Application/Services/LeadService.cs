using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.Entities.Leads;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Leads;
using MyCrm.Domain.ViewModels.Paging;
using static MyCrm.Domain.ViewModels.Leads.CreateLeadViewModel;
using static MyCrm.Domain.ViewModels.Leads.EditLeadViewModel;

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
        public async Task<CreateLeadResult> CreateLead(CreateLeadViewModel leadViewModel,long userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return CreateLeadResult.Error;
            }

            var lead = new Lead()
            {
                Company = leadViewModel.Company,
                CreatedById = userId,
                Description = leadViewModel.Description,
                Email = leadViewModel.Email,
                FirstName = leadViewModel.FirstName,
                LastName = leadViewModel.LastName,
                LeadStatus = LeadStatus.New,
                OwnerId = userId,
                Topic = leadViewModel.Topic,
                Mobile = leadViewModel.Mobile,
                IsWin = false
            };
            await _leadRepository.AddLead(lead);
            await _leadRepository.SaveChanges();

            return CreateLeadResult.Success;
        }

        public async Task<bool> DeleteLead(long leadId)
        {

            var lead = await _leadRepository.GetLeadById(leadId);
            if (lead == null)
            {
                return false;
            }
            lead.IsDelete = true;
            await _leadRepository.UpdateLead(lead);
            await _leadRepository.SaveChanges();
            return true;

        }

        public async Task<EditLeadResult> EditLead(EditLeadViewModel leadViewModel)
        {
            var lead = await _leadRepository.GetLeadById(leadViewModel.LeadId);
            if (lead == null)
            {
                return EditLeadResult.Error;
            }
           lead.Company = leadViewModel.Company;
           // lead.CreatedById = userId;
            lead.Description = leadViewModel.Description;
            lead.Email = leadViewModel.Email;
            lead.FirstName = leadViewModel.FirstName;
            lead.LastName = leadViewModel.LastName;
            lead.LeadStatus = LeadStatus.New;
            lead.OwnerId = lead.OwnerId;
            lead.Topic = leadViewModel.Topic;
            lead.Mobile = leadViewModel.Mobile;
            
            await _leadRepository.UpdateLead(lead);
            await _leadRepository.SaveChanges();

            return EditLeadResult.Success;
        }

        public async Task<EditLeadViewModel> FillEditViewModel(long leadId)
        {
            var lead = await _leadRepository.GetLeadById(leadId);
            if (lead == null)
            {
                return null;
            }
            var user = await _userRepository.GetUserById(leadId);
            if (user == null )
            {
                return null;
            }
            var result = new EditLeadViewModel()
            {
                LeadId = leadId,
                Description = lead.Description,
                Email = lead.Email,
                FirstName = lead.FirstName,
                LastName = lead.LastName,
                Company = lead.Company,
                Mobile = lead.Mobile,
                Topic = lead.Topic,
            };
            return result;
        }

        public async Task<FilterLeadViewModel> FilterLeads(FilterLeadViewModel filter)
        {
            var query = await _leadRepository.GetLeadQueryable();

            query = query.Where(a => !a.IsDelete);

            #region Filter

            if (!string.IsNullOrEmpty(filter.FilterLeadName))
            {
                query = query.Where(a => EF.Functions.Like(a.FirstName + " " + a.LastName, $"%{filter.FilterLeadName}%"));
            }

            if (!string.IsNullOrEmpty(filter.FilterLeadTopic))
            {
                query = query.Where(a => EF.Functions.Like(a.Topic, $"%{filter.FilterLeadTopic}%"));
            }


            switch (filter.FilterLeadState)
            {
                case FilterLeadState.All:
                    break;
                case FilterLeadState.Active:
                    query = query.Where(a => a.LeadStatus == LeadStatus.Active);
                    break;
                case FilterLeadState.Close:
                    query = query.Where(a => a.LeadStatus == LeadStatus.Close);
                    break;
                case FilterLeadState.New:
                    query = query.Where(a => a.LeadStatus == LeadStatus.New);
                    break;
            }

            #endregion

            #region paging

            var pager = Pager.build(filter.PageId, await query.CountAsync(), filter.TakeEntity,
                filter.HowManyShowPageafterAndBefore);

            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetEntity(allEntities).SetPaging(pager);
        }

        public async Task<EditLeadViewModel> GetLeadForEdit(long leadId)
        {
            var lead = await _leadRepository.GetLeadById(leadId);
            if (lead == null)
            {
                return null;
            }
            var result = new EditLeadViewModel()
            {
                Company = lead.Company,
                Description = lead.Description,
                Email = lead.Email,
                FirstName = lead.FirstName,
                LastName = lead.LastName,
                LeadId = lead.LeadId,
                Mobile = lead.Mobile,
                Topic = lead.Topic,
            };
            return result;
        }

        public async Task<bool> SetLeadToMarketer(long leadId, long marketerId)
        {
            var lead = await _leadRepository.GetLeadById(leadId);
            var marketer = await _userRepository.GetMarketerById(marketerId);
            if (lead == null || marketer == null)
            {
                return false;
            }
            lead.OwnerId = marketerId;
            await _leadRepository.UpdateLead(lead);
            await _leadRepository.SaveChanges();

            return true;
        }
    }
}
