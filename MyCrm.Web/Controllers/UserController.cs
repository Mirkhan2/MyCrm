using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Interface;
using MyCrm.Domain.ViewModels.User;

namespace MyCrm.Web.Controllers
{
    public class UserController : Controller
    {

        #region ctor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region User List

        public async Task<IActionResult>  Index(FilterUserViewModel filter)
        {
              return View();
        }

        #endregion



        #region Add User

        #region Create Customer

        public async Task<IActionResult> CreateCustomer()
        {
            return View();
        }

        #endregion

        #region CreateMarketer

        public async Task<IActionResult> CreateMarketer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarketer(AddMarketerViewModel marketer)
        {
            if (!ModelState.IsValid)
            {
                return View(marketer);
            }

            var res = await _userService.AddMarketer(marketer);

            switch (res)
            {
                case AddMarketerResult.Success:
                    return RedirectToAction("Index");
                case AddMarketerResult.Fail:
                    ModelState.AddModelError("UserName", "مشکلی در ثبت اطلاعات میباشد");
                    break;
            }

            return View(marketer);
        }

        #endregion

        #endregion
    }
}
