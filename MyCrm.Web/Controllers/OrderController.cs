using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;

namespace MyCrm.Web.Controllers
{
    public class OrderController : Controller
    {
        #region ctor
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        public OrderController(IOrderService orderService,IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }
        #endregion
        public async Task<IActionResult> CreateOrder(long id)
        {
            ViewBag.customer = await _userService.GetCustomerById(id);

            if (ViewBag.customer == null)
            {
                return NotFound();
            }

            return View();
        }
    }
}
