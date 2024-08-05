using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.Entities.Tasks;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Actions;
using MyCrm.Domain.ViewModels.MarketingAction;
using MyCrm.Domain.ViewModels.Paging;
using MyCrm.Domain.ViewModels.Tasks;
using static MyCrm.Domain.ViewModels.Tasks.EditTaskViewModel;

namespace MyCrm.Application.Services
{
    public class TaskService : ITaskService
    {
        #region Ctor
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        #endregion
        public async Task<CreateTaskResult> CreateTask(CreateTaskViewModel taskViewModel)
        {
            var task = new CrmTask()
            {
                //MarketingActions = taskViewModel.ma
                Description = taskViewModel.Description,
                MarketerId = taskViewModel.MarketerId,
                OrderId = taskViewModel.OrderId,
                Priority = taskViewModel.Priority,
                UntilDate = taskViewModel.UntilDate,
                TaskStatus = taskViewModel.TaskStatus

            };
            await _taskRepository.AddTask(task);
            await _taskRepository.SaveChange();

            return CreateTaskResult.Success;

        }

        public async Task<bool> DeleteTask(long taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                return false;
            }
            task.IsDelete = true;
            await _taskRepository.UpdateTask(task);
            await _taskRepository.SaveChange();

            return true;
        }

        public async Task<EditTaskResult> EditTask(EditTaskViewModel taskViewModel)
        {
            var task =  await _taskRepository.GetTaskById(taskViewModel.TaskId);
            if (task == null)
            {
                return EditTaskResult.Fail;
            }
            task.Description = taskViewModel.Description;
            task.Priority = taskViewModel.Priority;
            task.UntilDate = taskViewModel.UntilDate;
            task.TaskStatus = taskViewModel.TaskStatus;

            await _taskRepository.UpdateTask(task);
            await _taskRepository.SaveChange();

            return EditTaskResult.Success;
        }

        public async Task<EditTaskViewModel> FillEditTaskViewModel(long taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                return null;
            }
            var user = await _taskRepository.GetTaskById(taskId);
            if (user == null)
            {
                return null;
            }
            var result = new EditTaskViewModel()
            {
                Description = task.Description,
                MarketerId = task.MarketerId,
                OrderId = task.OrderId,
                Priority = task.Priority,
                TaskId = task.TaskId,
                UntilDate = task.UntilDate,
                TaskStatus = task.TaskStatus

            };
            return result;
        }

        public async Task<TaskDetailViewModel> FillTaskDetailViewModel(long taskId)
        {
            var taskQueryable = await _taskRepository.GetTasksQueryable();

            var task = await taskQueryable
                .Include(a => a.Marketer)
                .ThenInclude(a => a.User)
                .FirstOrDefaultAsync(a => a.TaskId == taskId);

            if (task == null)
            {
                return null;
            }

            var result = new TaskDetailViewModel()
            {
                Task = task,
                ActionCount = _taskRepository.GetActionQueryable().Result.Count(a => a.CrmTaskId == taskId),
               // MarketingActions = await _taskRepository.GetActionQueryable().Result.Where(a => a.CrmTaskId == taskId && !a.IsDelete).ToListAsync()
            };

            return result;
        }

        public async Task<FilterTaskViewModel> FilterTask(FilterTaskViewModel filter)
        {
            var query = await _taskRepository.GetTasksQueryable();

            #region Filter
            query = query.Where(a => a.IsDelete);
            if (string.IsNullOrEmpty(filter.FilterCustomerName))
            {query = query.Where(a
               => EF.Functions.Like(a.Order.Customer.User.FirstName , $"%{filter.FilterCustomerName}%") ||
              EF.Functions.Like(a.Order.Customer.User.LastName, $"%{filter.FilterCustomerName}%") ||
              EF.Functions.Like(a.Order.Customer.User.LastName, $"%{filter.FilterCustomerName}%") );

            }
            if (string.IsNullOrEmpty(filter.FilterCustomerName))
            {
                query = query.Where(a => EF.Functions.Like(a.Marketer.User.FirstName + "" + a.Marketer.User.LastName, $"%{filter.FilterCustomerName}%"));

            }
            #endregion

            #region task
            query = query.OrderByDescending(a => a.CreateDate);
            #endregion

            #region paging
            var pager = Pager.build(filter.PageId, filter.AllEntitiesCount, filter.TakeEntity,
                filter.HowManyShowPageafterAndBefore);
            var AllEntities = await query.Paging(pager).ToListAsync();
            #endregion
            return filter.SetEntity(AllEntities).SetPaging(pager);
        }

        public async Task<EditTaskViewModel> GetTaskForEdit(long taskId)
        {
            var task = await _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                return null;

            }
            var result = new EditTaskViewModel()
            {
                Description = task.Description,
                MarketerId = task.MarketerId,
                OrderId = task.OrderId,
                Priority = task.Priority,
                TaskId = task.TaskId,

            };
            return result;
        }

        public async Task<CreateMarketingActionResult> CreateMarketingActionResult(CreateMarketingActionViewModel action)
        {
            var task = await _taskRepository.GetTaskById(action.CrmTaskId);
            if (task == null)
            {
                return Domain.ViewModels.MarketingAction.CreateMarketingActionResult.Fail;
            }

            var newAction = new MarketingAction()
            {
                Description = action.Description,
                CrmTaskId = action.CrmTaskId,

            };
            await _taskRepository.AddAction(newAction);
            await _taskRepository.SaveChange();

            return Domain.ViewModels.MarketingAction.CreateMarketingActionResult.Success;
        }

        public async Task<bool> ChangeTaskState(long taskId, CrmTaskStatus crmTaskStatus)
        {
            var task = await _taskRepository.GetTaskById(taskId);
            if (task == null)
            {
                return false;
            }
            task.TaskStatus = crmTaskStatus;
            await _taskRepository.UpdateTask(task);
            await _taskRepository.SaveChange();

            return true;
        }
    }
}
