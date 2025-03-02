using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Tasks;
using MyCrm.Domains.ViewModels.MarketingAction;
using MyCrm.Domains.ViewModels.Tasks;
using static MyCrm.Domains.ViewModels.Tasks.EditTaskViewModel;

namespace MyCrm.Application.Interfaces
{
    public interface ITaskService
    {
        Task<CreateTaskResult> CreateTask(CreateTaskViewModel taskViewModel);
        Task<FilterTaskViewModel> FilterTask(FilterTaskViewModel filter);
        Task<EditTaskViewModel> GetTaskForEdit(long taskId);
        Task<EditTaskResult> EditTask(EditTaskViewModel taskViewModel);
        Task<EditTaskViewModel> FillEditTaskViewModel(long taskId);
        Task<bool> DeleteTask(long taskId);
        Task<TaskDetailViewModel> FillTaskDetailViewModel(long taskId);
        #region Action
        Task<CreateMarketingActionResult> CreateMarketingActionResult(CreateMarketingActionViewModel action);



        #endregion
        Task<bool> ChangeTaskState(long taskId, CrmTaskStatus crmTaskStatus);

    }
}
