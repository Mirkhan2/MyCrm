using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.ViewModels.Leads;
using static MyCrm.Domain.ViewModels.Leads.CreateLeadViewModel;
using static MyCrm.Domain.ViewModels.Leads.EditLeadViewModel;

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

            ViewData["marketerList "] = await _userService.GetMarketerList();

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
                TempData[WarningMessage] = "INformationen isnt Waalid gultig";
                return View(leadViewModel);
            }
            var result = await _leadService.CreateLead(leadViewModel, User.GetUserId());

            switch (result)
            {
                case CreateLeadResult.Success:
                    TempData[SuccessMessage] = "Successd";
                    return RedirectToAction("FilterLeads");
                case CreateLeadResult.Error:
                    TempData[ErrorMessage] = "tschuss";
                    break;

            }
            return View(leadViewModel);
        }
        #endregion

        #region Edit
        public async Task<IActionResult> EditLead(long lead)
        {
            var model = await _leadService.FillEditViewModel(lead);
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
                TempData[WarningMessage] = "";
                return View(leadViewModel);
            }
            var result = await _leadService.EditLead(leadViewModel);

            switch (result)
            {
                case EditLeadResult.Success:
                    TempData[SuccessMessage] = "success";
                    return RedirectToAction("FilterLeads");
                    
                case EditLeadResult.Error:
                    TempData[ErrorMessage] = "shekast";
                    
                
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
                TempData[SuccessMessage] = "movafaqiat";
            }
            else
            {
                TempData[ErrorMessage] = " shekast";
            }
            return RedirectToAction("FilterLeads");
        }

        #endregion

        #region Set LeadTo marketer
        [HttpPost]
        public async Task<IActionResult> SetLeadToMarketer(long leadId,long MarketerId)
        {
            var result = await _leadService.SetLeadToMarketer(leadId, MarketerId);
             if(result)
            {
                TempData[SuccessMessage] = "amaliat gut";
            }
            else
            {
                TempData[ErrorMessage] = "amalait shekast";
            }

            return RedirectToAction("FilterLeads");
        }
        #endregion

        #region Change State
        [HttpPost]
        public async Task<IActionResult> ChangeState(long leadId,int stateIndex)
        {
            var result = await _leadService.ChangeLeadState(leadId,stateIndex);
            if (result)
            {
                TempData[SuccessMessage] = "amaliat movafaqiat";
            }
            else
            {
                TempData[ErrorMessage] = "";
            }
            return RedirectToAction("Filterleads");
        }
        #endregion

        #region Close and win
        public async Task<IActionResult> CloseAndWinLead(long leadId)
        {
            var result  =await _leadService.CloseAndWinLead(leadId);
            if (result)
            {
                TempData[SuccessMessage] = "";
            }
            else
            {
                TempData[ErrorMessage] = "";
            }

            return RedirectToAction("FilterLeads");
        }
        #endregion
    }
}
