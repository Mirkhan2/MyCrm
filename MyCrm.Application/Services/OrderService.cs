using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interfaces;
using MyCrm.Application.Security;
using MyCrm.Application.Static_Tools;
using MyCrm.Domain.Entities.Orders;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Orders;

namespace MyCrm.Application.Services
{
    public class OrderService : IOrderService
    {
        #region Ctpr
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
                _orderRepository = orderRepository;
        }
        #endregion
        public async Task<CreateOrderResult> CreateOrder(CreateOrderViewModel orderViewModel, IFormFile imageName)
        {
            var orderImage = "";

            if (imageName?.Length > 0)
            {
                orderImage = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imageName.FileName);
                imageName.AddImageToServer(orderImage, FilePath.OrderImagePathServer, 280, 280);
            }

            //var result = new Order_orderRepository.AddOrder();
            //await _orderRepository.AddOrder(result);
            //return result;
            var order = new Order()
            {
                Description = orderViewModel.Description,
              //  OrderType = orderViewModel.OrderType,
                Title = orderViewModel.Title,
                CustomerId = orderViewModel.CustomerId,

                //CustomerId = orderViewModel.CustomerId,
                //OrderId = orderViewModel.OrderId,

            };

            if (!string.IsNullOrEmpty(orderImage))
            {
                order.ImageName = orderImage;
            }

            await _orderRepository.AddOrder(order);
            await _orderRepository.SaveChange();

            return CreateOrderResult.Success;
        }
    }
}
