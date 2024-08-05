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
        private readonly IOrderService _orderService;
        public TaskController(ITaskService taskService, IUserService userService,IOrderService orderService)
        {
                _taskService = taskService;
            _userService = userService;
            _orderService = orderService;
        }
        #endregion

        #region Filter Task
        public async Task<IActionResult> FilterTasks(FilterTaskViewModel filter)
        {
            var result = await _taskService.FilterTask(filter);
            return View(result);
        }
        #endregion


        #region Detail

        public async Task<IActionResult> TaskDetail(long taskId)
        {
            var model = await _taskService.FillTaskDetailViewModel(taskId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Create Task

        public async Task<IActionResult> CreateTask(long? orderId)
        {
            var model = new CreateTaskViewModel();

            if (orderId != null)
            {
                model.OrderId = orderId.Value;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskViewModel taskViewModel)
        {
            if (!TryValidateModel(taskViewModel))
            {
                TempData[WarningMessage] = "اطلاعات وارد شده معتبر نمیباشد";
                return View(taskViewModel);
            }

            taskViewModel.MarketerId = User.GetUserId();

            var result = await _taskService.CreateTask(taskViewModel);

            switch (result)
            {
                case CreateTaskResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterTask");
                case CreateTaskResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(taskViewModel);
        }

        #endregion

        #region Edit

        public async Task<IActionResult> EditTask(long taskId)
        {
            var model = await _taskService.FillEditTaskViewModel(taskId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditTask(EditTaskViewModel taskViewModel)
        {
            if (!TryValidateModel(taskViewModel))
            {
                TempData[WarningMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(taskViewModel);
            }

            var result = await _taskService.EditTask(taskViewModel);

            switch (result)
            {
                case EditTaskResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterTask");
                case EditTaskResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(taskViewModel);
        }

        #endregion

        #region CHange Task State
        public async Task<IActionResult> ChangeTaskStateToClose(long taskId)
        {
            var result = await _taskService.ChangeTaskState(taskId , Domain.Entities.Tasks.CrmTaskStatus.Close);

            if (result)
            {
                TempData[SuccessMessage] = "amaloat 20";
            }
            else
            {
                TempData[ErrorMessage] = " shekast";
            }
            return RedirectToAction("FilterTask");
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

        #region Finish Order Marketing 
        public async Task<IActionResult> FinishOrderMarketing(long orderId, long taskId)
        {

            var result = await _orderService.ChangeOrderToFinish(orderId, taskId);

            if (result)
            {
                TempData[SuccessMessage] = " Bestanden";
            }
            else
            {
                TempData[ErrorMessage] = "Verloren";
            }
            return RedirectToAction("FilterTask");
        }
        #endregion
    }
}
