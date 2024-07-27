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
    }
}
 