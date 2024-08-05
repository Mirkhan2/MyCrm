using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
using MyCrm.Domain.ViewModels.Orders;
using MyCrm.Domain.ViewModels.User;

namespace MyCrm.Web.Controllers
{
    public class OrderController : BaseController
    {
        #region ctor

        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IPredictService _predictService;

        public OrderController(IOrderService orderService, IUserService userService,IPredictService predictService)
        {
            _orderService = orderService;
            _userService = userService;
            _predictService = predictService;
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
                 TempData[WarningMessage] = "اطلاعات وارد شده صحیح نمی باشد";
                return View(orderViewModel);
            }

            var result = await _orderService.CreateOrder(orderViewModel, orderImage);

            switch (result)
            {
                case CreateOrderResult.Success:
                     TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
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
             TempData[WarningMessage] = "اطلاعات وارد شده معتبر نمی باشد";
                return View(orderViewModel);

            }
            var result = await _orderService.EditOrder(orderViewModel, imageProfile);
            switch (result)
            {
                case EditOrderResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("FilterOrders");
                case EditOrderResult.Fail:
                    TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                    break;
            }
            return View(orderViewModel);
        }
        #endregion

        #region Delete Order
        public async Task<IActionResult> DeleteOrder(long orderId)
        {
            var result = await _orderService.DeleteOrder(orderId);

            if (result)
            {
                TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                return RedirectToAction("FilterOrders");
            }
            else
            {
                TempData[ErrorMessage] = "عملیات با شکست مواجه شد";
                return RedirectToAction("FilterOrders");
            }
        }
        #endregion

        #region Select Marketer For Order

        public async Task<IActionResult> SelectMarketerModal(long orderId)
        {
            var model = new OrderSelectMarketerViewModel { OrderId = orderId };

            ViewBag.Marketers = await _userService.GetMarketerList();

            ViewBag.MarketerPredict = await _predictService.GetMarketerPredict();

            return PartialView("_SelectMarketerPartial", model);
        }
        [HttpPost]
        public async Task<IActionResult> SelectMarketerModal(OrderSelectMarketerViewModel orderSelectMarketerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { status = "NOtValid" });
            }

            var result = await _orderService.AddOrderSelectMarketer(orderSelectMarketerViewModel, User.GetUserId());
            switch (result)
            {
                case AddOrderSelectMarketerResult.Success:
                    return new JsonResult(new { status = "Success" });
               
                case AddOrderSelectMarketerResult.Fail:
                    return new JsonResult(new { status = "Error" });

                case AddOrderSelectMarketerResult.SelectedMarketerExist:
                    return new JsonResult(new { status = "Exist" });
            }

            return new JsonResult(new { status = "Error" });
        }

        #endregion

        #region Selected Marketer List

        public async Task<IActionResult> FilterOrderSelectedMarketer(FilterOrderSelectedMarketer filter)
        {
            var result = await _orderService.FilterOrderSelectedMarketer(filter);
            return View(result);
        }
        #endregion

        #region Delete Order Selected Marketer
        public async Task<IActionResult> DeleteOrderSelectedmarketer(long orderId)
        {
            var result = await _orderService.DeleteOrderSelectedMarketer(orderId);
            if (result)
            {
            //    TempData[ErrorMessage] = "shekast";

                return RedirectToAction("FilterOrderSelectedMarketer");
                  }
         //   TempData[SuccesMessage] = " Dorost";
            return RedirectToAction("FilterOrderSelectedMarketer");


        }
        #endregion

    }
}
