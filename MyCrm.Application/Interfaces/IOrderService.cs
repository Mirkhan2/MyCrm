using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Domain.ViewModels.Orders;

namespace MyCrm.Application.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderResult> CreateOrder(CreateOrderViewModel orderViewModel, IFormFile imageName);
        Task<FilterOrderViewModel> FilterOrder(FilterOrderViewModel filter);
        Task<EditOrderViewModel> GetOrderForEdit(long orderId);
        Task<EditOrderResult> EditOrder(EditOrderViewModel orderViewModel, IFormFile imageProfile);
        Task<EditOrderViewModel> FillEditOrderViewModel(long orderId);
        Task<bool> DeleteOrder(long orderId);
        Task<AddOrderSelectMarketerResult> AddOrderSelectMarketer(OrderSelectMarketerViewModel marketerViewModel, long userId);
    }
}
 