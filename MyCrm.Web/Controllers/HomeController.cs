using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interfaces;

namespace MyCrm.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region ctor
        private readonly IProgramSetting _programSetting;
        private readonly IPredictService _predictService;

        public HomeController(IProgramSetting programSetting, IPredictService predictService)
        {
            _programSetting = programSetting;
            _predictService = predictService;   
        }
        #endregion
        public async Task<IActionResult>  Index()
        {
            var result = await _programSetting.FillDashboardViewModel(User.GetUserId());
            ViewBag.Month = result.SelfUser.Events;
            return View(result);
        }
        public async Task<IActionResult> ProcessPredictMarketer()
        {
            var result = await _predictService.ProcessMarketerPredict();
            if (result)
            {
                TempData[SuccessMessage] = "عمیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عمیات با شکست مواجه شد";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetStringPastsMonth(int count)
        {
            return Json(Enumerable.Reverse(DateTime.Now.GetContPastMonths(count)));
        }
    }
}
