using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.ViewModels.Leads;
using static MyCrm.Domain.ViewModels.Leads.CreateLeadViewModel;
using static MyCrm.Domain.ViewModels.Leads.EditLeadViewModel;

namespace MyCrm.Application.Interfaces
{
    public interface ILeadService
    {
        Task<CreateLeadResult> CreateLead(CreateLeadViewModel leadViewModel,long userId);
        Task<FilterLeadViewModel> FilterLeads(FilterLeadViewModel filter);
        Task<EditLeadViewModel> GetLeadForEdit(long leadId);
        Task<EditLeadResult> EditLead(EditLeadViewModel leadViewModel);
        Task<EditLeadViewModel> FillEditViewModel(long  leadId);
        Task<bool> DeleteLead(long leadId);
        Task<bool> SetLeadToMarketer(long leadId, long marketerId);





    }
}
