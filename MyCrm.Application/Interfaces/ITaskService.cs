using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.ViewModels.Tasks;
using static MyCrm.Domain.ViewModels.Tasks.EditTaskViewModel;

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


    }
}
