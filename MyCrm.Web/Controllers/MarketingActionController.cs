using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.ViewModels.MarketingAction;

namespace MyCrm.Web.Controllers
{
    public class MarketingActionController : BaseController
    {

        #region Ctor

        private readonly ITaskService _taskService;

        public MarketingActionController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        #endregion

        #region Create

        public async Task<IActionResult> CreateAction(long taskId)
        {
            var model = new CreateMarketingActionViewModel()
            {
                CrmTaskId = taskId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAction(CreateMarketingActionViewModel actionViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(actionViewModel);
            }

            var result = await _taskService.CreateMarketingActionResult(actionViewModel);

            switch (result)
            {
                case CreateMarketingActionResult.Success:
                    TempData[SuccessMessage] = "عملیات شما با موفقیت انجام شد";
                    return RedirectToAction("TaskDetail", "Task", new { taskId = actionViewModel.CrmTaskId });
                case CreateMarketingActionResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }


            return View(actionViewModel);
        }

        #endregion
    }
}
