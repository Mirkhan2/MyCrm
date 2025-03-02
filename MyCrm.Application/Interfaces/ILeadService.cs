using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.ViewModels.Events;
using MyCrm.Domains.ViewModels.Leads;

namespace MyCrm.Application.Interfaces
{
    public interface ILeadService
    {
        Task<CreateLeadResult> CreateLead(CreateLeadViewModel leadViewModel, long userId);

        Task<EditLeadResult> EditLead(EditLeadViewModel leadViewModel);

        Task<EditLeadViewModel> FillEditLeadViewModel(long leadId);

        Task<bool> DeleteLead(long leadId);

        Task<FilterLeadViewModel> FilterLeads(FilterLeadViewModel filter);

        Task<bool> SetLeadToMarketer(long leadId, long marketerId);

        Task<bool> ChangeLeadState(long leadId, int stateIndex);

        Task<bool> CloseAndWinLead(long leadId);
    }
}
