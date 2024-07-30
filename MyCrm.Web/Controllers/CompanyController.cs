using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Company;

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
        public async Task<IActionResult> FilterCompanies()
        {
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
            if(!ModelState.IsValid)
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
                    break;
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
    }
}
