using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Interface;
using MyCrm.Domain.ViewModels.User;
using static MyCrm.Domain.ViewModels.User.AddCustomerViewModel;

namespace MyCrm.Web.Controllers
{
    public class UserController : BaseController
    {
        #region ctor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region User List

        [HttpGet]
        public async Task<IActionResult> Index(FilterUserViewModel filter)
        {
            var result = await _userService.FilterUser(filter);
            return View(result);
        }

        #endregion

        #region Add User

        #region Create Customer

        [HttpGet]
        public async Task<IActionResult> CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(AddCustomerViewModel customerViewModel, IFormFile MainImage)
        {
            if (!ModelState.IsValid)
            {
                TempData[Errormessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(customerViewModel);
            }

            var result = await _userService.AddCustomer(customerViewModel, MainImage);

            switch (result)
            {
                case AddCustomerResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Index");
                case AddCustomerResult.Fail:
                    TempData[Errormessage] = "عملیات با شکست مواجه شد";
                    break;
            }
            return View(customerViewModel);
        }

        #endregion

        #region CreateMarketer

        public async Task<IActionResult> CreateMarketer()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateMarketer(AddMarketerViewModel marketer, IFormFile imageProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(marketer);
            }

            var res = await _userService.AddMarketer(marketer, imageProfile);

            switch (res)
            {
                case AddMarketerResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Index");
                case AddMarketerResult.Fail:
                    TempData[Errormessage] = "عملیات با شکست مواجه شد";
                    ModelState.AddModelError("UserName", "مشکلی در ثبت اطلاعات میباشد");
                    break;
            }

            return View(marketer);
        }

        #endregion

        #endregion

        #region Edit User

        #region Edit Marketer

        [HttpGet]
        public async Task<IActionResult> EditMarketer(long id)
        {
            var result = await _userService.GetMarketerForEdit(id);

            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditMarketer(EditMarketerViewModel marketer, IFormFile imageProfile)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "اطلاعات وارد شده کامل نمی باشد";
                return View(marketer);
            }

            var result = await _userService.EditMarketer(marketer, imageProfile);

            switch (result)
            {
                case EditMarketerResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Index");
                case EditMarketerResult.Fail:
                    TempData[Errormessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(marketer);
        }

        #endregion

        #region Edit Customer

        public async Task<IActionResult> EditCustomer(long id)
        {
            var result = await _userService.FillEditCustomerViewModel(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(EditCustomerViewModel customerViewModel, IFormFile imageProfile)
        {
            if (!ModelState.IsValid)
            {
                TempData[Errormessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(customerViewModel);
            }

            var result = await _userService.EditCustomer(customerViewModel, imageProfile);

            switch (result)
            {
                case EditCustomerResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Index");
                case EditCustomerResult.Fail:
                    TempData[Errormessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(customerViewModel);
        }

        #endregion

        #endregion

        #region Delete User

        public async Task<IActionResult> DeleteUser(long userId)
        {
            var result = await _userService.DeleteUser(userId);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Errormessage] = "عملیات با شکست مواجه شد";
                return RedirectToAction("Index");
            }
        }

        #endregion
    }

}
