using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.ViewModels.Orders;
using MyCrm.Domain.ViewModels.User;

namespace MyCrm.Web.Controllers
{
    public class OrderController : Controller
    {
        #region ctor

        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        #endregion

        #region Filter Orders

        public async Task<IActionResult> FilterOrders(FilterOrderViewModel filter)
        {
            var result = await _orderService.FilterOrder(filter);
            return View(result);
        }

        #endregion

        #region Create Order

        public async Task<IActionResult> CreateOrder(long id)
        {
            ViewBag.customer = await _userService.GetCustomerById(id);

            if (ViewBag.customer == null)
            {
                return NotFound();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel orderViewModel, IFormFile orderImage)
        {
            ViewBag.customer = await _userService.GetCustomerById(orderViewModel.CustomerId);

            if (!ModelState.IsValid)
            {
                // TempData[Warningmessage] = "اطلاعات وارد شده صحیح نمی باشد";
                return View(orderViewModel);
            }

            var result = await _orderService.CreateOrder(orderViewModel, orderImage);

            switch (result)
            {
                case CreateOrderResult.Success:
                    // TempData[Successmessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterOrders");
                    break;
                case CreateOrderResult.Fail:
                    //TempData[Errormessage] = "عملیات با شکست مواجه شد";
                    break;
            }

            return View(orderViewModel);
        }

        #endregion

        #region Edit Order

        public async Task<IActionResult> EditOrder(long order)
        {
            //Tofo FilleditCustomerViewModel
            var result = await _orderService.FillEditOrderViewModel(order);
            ViewBag.customer = await _userService.GetCustomerById(result.CustomerId);
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> EditOrder(EditOrderViewModel orderViewModel, IFormFile imageProfile)
        {

            ViewBag.customer = await _userService.GetCustomerById(orderViewModel.CustomerId);

            if (!ModelState.IsValid)
            {
          //      TempData[Warningmessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(orderViewModel);

            }
            var result = await _orderService.EditOrder(orderViewModel, imageProfile);
            switch (result)
            {
                case EditOrderResult.Success:
            //        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterOrders");
                case EditOrderResult.Fail:
              //      TempData[Errormessage] = "عملیات با شکست مواجه شد";
                    break;
            }
            return View(orderViewModel);
        }
        #endregion
    }
}
