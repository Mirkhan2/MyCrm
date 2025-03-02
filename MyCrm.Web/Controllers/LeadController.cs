using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
using MyCrm.Domains.ViewModels.Events;
using MyCrm.Domains.ViewModels.Leads;

namespace MyCrm.Web.Controllers
{
    public class LeadController : BaseController
    {
        #region Ctor

        private readonly ILeadService _leadService;
        private readonly IUserService _userService;

        public LeadController(ILeadService leadService, IUserService userService)
        {
            _leadService = leadService;
            _userService = userService;
        }

        #endregion

        #region Filter

        public async Task<IActionResult> FilterLeads(FilterLeadViewModel filter)
        {
            var model = await _leadService.FilterLeads(filter);

            ViewData["marketerList"] = await _userService.GetMarketerList();

            return View(model);
        }

        #endregion

        #region Create

        public async Task<IActionResult> CreateLead()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLead(CreateLeadViewModel leadViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(leadViewModel);
            }

            var result = await _leadService.CreateLead(leadViewModel, User.GetUserId());

            switch (result)
            {
                case CreateLeadResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterLeads");
                case CreateLeadResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(leadViewModel);
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> EditLead(long leadId)
        {
            var model = await _leadService.FillEditLeadViewModel(leadId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditLead(EditLeadViewModel leadViewModel)
        {
            if (!TryValidateModel(leadViewModel))
            {
                TempData[WarningMessage] = "اطلاعات وارد شده معتبر نمیباشد";
                return View(leadViewModel);
            }

            var result = await _leadService.EditLead(leadViewModel);

            switch (result)
            {
                case EditLeadResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterLeads");
                case EditLeadResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(leadViewModel);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> DeleteLead(long leadId)
        {
            var result = await _leadService.DeleteLead(leadId);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterLeads");
        }

        #endregion

        #region Set Lead to marketer

        [HttpPost]
        public async Task<IActionResult> SetLeadToMarketer(long LeadId, long MarketerId)
        {
            var result = await _leadService.SetLeadToMarketer(LeadId, MarketerId);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterLeads");
        }

        #endregion

        #region Change State

        [HttpPost]
        public async Task<IActionResult> ChangeState(long leadId, int stateIndex)
        {
            var result = await _leadService.ChangeLeadState(leadId, stateIndex);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterLeads");
        }

        #endregion

        #region Close and win

        public async Task<IActionResult> CloseAndWinLead(long leadId)
        {
            var result = await _leadService.CloseAndWinLead(leadId);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
            }

            return RedirectToAction("FilterLeads");
        }

        #endregion
    }
}
