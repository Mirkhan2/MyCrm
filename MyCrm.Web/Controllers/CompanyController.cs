using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Interfaces;
using MyCrm.Domains.ViewModels.Company;

namespace MyCrm.Web.Controllers
{
    public class CompanyController : Controller
    {
        #region ctor
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        #endregion

        #region list
        public async Task<IActionResult> FilterCompanies(FilterCompanyViewModel filter)
        {
            var result = await _companyService.FilterCompany(filter);

            return View();
        }
        #endregion

        #region CreateCompany
        public async Task<IActionResult> CreateCompany(long id)
        {

            return View();
            // ViewBag.company = await _companyService.getc
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCompanyViewModel companyViewModel)
        {

            ViewBag.company = await _companyService.CreateCompany(companyViewModel);
            if (!ModelState.IsValid)
            {
                // TempData[WarningMessage] = "1;1;";
                return View(companyViewModel);
            }

            var result = await _companyService.CreateCompany(companyViewModel);

            switch (result)
            {
                case CreateCompanyResult.Success:

                    //  TempData[SuccessMessage] = "1;1;";
                    return RedirectToAction("FilterCompanies");
                case CreateCompanyResult.Error:

                    // TempData[ErrorMessage] = "1;1;";
                    break;
                default:
                    break;
            }

            //  return RedirectToAction("FilterCompanies");
            return View(companyViewModel);
        }
        #endregion
        #region Edit Company
        public async Task<IActionResult> EditCompany(long company)
        {
            var res = await _companyService.FillEditCompanyViewModel(company);
            if (res == null)
            {
                return NotFound();
            }
            //  ViewBag.company = await _companyService.GetCompanyForEdit(res.Id);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> EditCompany(EditCompanyViewModel companyViewModel)
        {
            ViewBag.customer = await _companyService.GetCompanyForEdit(companyViewModel.Id);
            if (!ModelState.IsValid)
            {
                //TempData[WarningMessage] = " la doros";
                return View(companyViewModel);
            }
            var result = await _companyService.EditCompany(companyViewModel);
            switch (result)
            {
                case EditCompanyResult.Success:
                    return RedirectToAction("");

                case EditCompanyResult.Error:
                    break;

            }
            return View(companyViewModel);
        }
        #endregion
        #region Delete Company
        public async Task<IActionResult> DeleteCompany(long companyId)
        {
            var result = await _companyService.DeleteCompany(companyId);
            if (result)
            {
                return RedirectToAction("");
            }
            else
            {
                return RedirectToAction("");
            }
        }
        #endregion
    }
}
