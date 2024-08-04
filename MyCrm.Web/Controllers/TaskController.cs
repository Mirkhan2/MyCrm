using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.ViewModels.Tasks;
using static MyCrm.Domain.ViewModels.Tasks.EditTaskViewModel;

namespace MyCrm.Web.Controllers
{
    public class TaskController : BaseController
    {
        #region Ctor
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        public TaskController(ITaskService taskService, IUserService userService)
        {
                _taskService = taskService;
            _userService = userService;
        }
        #endregion

        #region Filter Task
        public async Task<IActionResult> FilterTasks(FilterTaskViewModel filter)
        {
            var result = await _taskService.FilterTask(filter);
            return View(result);
        }
        #endregion

        #region Create Task
    
        public async Task<IActionResult> CreateTask(long? orderId)
        {
            var model = new CreateTaskViewModel();

            if (orderId! = null)
            {
                model.OrderId = orderId.Value;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskViewModel taskViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "info طلاعات وارد شده معتبر نمیباشد";
                return View(taskViewModel);

            }
            var result = await _taskService.CreateTask(taskViewModel );
            switch (result)
            {
                case CreateTaskResult.Success:
                    TempData[SuccessMessage] = " عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterTasks");
                case CreateTaskResult.Fail:
                    TempData[ErrorMessage] = "vعملیات با شکست مواجه شد";
                
                    break;
            }
            return View(taskViewModel);
        }
        #endregion

        #region Edit Task
        public async Task<IActionResult> EditTask(long task)
        {
            var model = await _taskService.FillEditTaskViewModel(task);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
         public async Task<IActionResult> EditTask(EditTaskViewModel taskViewModel)
        {
            if (!TryValidateModel(taskViewModel))
            {
                TempData[WarningMessage] = "";
                return View(taskViewModel);
            }
            var result = await _taskService.EditTask(taskViewModel);
            switch (result)
            {
                case EditTaskResult.Success:
                    TempData[SuccessMessage] = "success";
                    return RedirectToAction("FilterTasks");
                case EditTaskResult.Fail:
                    TempData[ErrorMessage ] = "error";
                    break;
              
            }
            return View(taskViewModel);

        }
        #endregion

        #region Delete Task
         public async Task<IActionResult> DeleteTask(long taskId)
        {
            var result = await _taskService.DeleteTask(taskId);
            if (result)
            {
                TempData[SuccessMessage] = " Bestanden";
            }
            else
            {
                TempData[ErrorMessage] = "Verloren";
            }
            return RedirectToAction("FilterTasks");
        }
        #endregion
    }
}
