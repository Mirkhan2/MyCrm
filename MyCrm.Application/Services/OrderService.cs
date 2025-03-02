using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyCrm.Application.Extensions;
using MyCrm.Application.Interfaces;
using MyCrm.Application.Security;
using MyCrm.Application.StaticTools;
using MyCrm.Domains.Entities.Orders;
using MyCrm.Domains.Entities.Tasks;
using MyCrm.Domains.Interfaces;
using MyCrm.Domains.ViewModels.Orders;
using MyCrm.Domains.ViewModels.Paging;

namespace MyCrm.Application.Services
{
    public class OrderService : IOrderService
    {
        #region Ctor
        private readonly IOrderRepository _orderRepository;
        private readonly ITaskService _TaskService;
        public OrderService(IOrderRepository orderRepository, ITaskService taskService)
        {
            _orderRepository = orderRepository;
            _TaskService = taskService;

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
                PredictDay = orderViewModel.PredictDay,
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



        public async Task<FilterOrderViewModel> FilterOrder(FilterOrderViewModel filter)
        {
            var query = await _orderRepository.GetOrders();

            #region filter

            query = query.Where(a => a.IsDelete);

            if (string.IsNullOrEmpty(filter.FilterCustomerName))
            {
                query = query.Where(a
                    => EF.Functions.Like(a.Customer.User.FirstName, $"%{filter.FilterCustomerName}%") ||
                       EF.Functions.Like(a.Customer.User.LastName, $"%{filter.FilterCustomerName}%") ||
                     EF.Functions.Like(a.Customer.User.FirstName + " " + a.Customer.User.LastName, $"%{filter.FilterCustomerName}%"));


            }
            if (string.IsNullOrEmpty(filter.FilterOrderName))
            {
                query = query.Where(a => EF.Functions.Like(a.Title, $"%{filter.FilterOrderName}%"));

            }
            #endregion

            #region order
            query = query.OrderByDescending(a => a.CreateDate);
            #endregion

            #region paging
            var pager = Pager.build(filter.PageId, filter.AllEntitiesCount, filter.TakeEntity,
             filter.HowManyShowPageAfterAndBefore);

            var AllEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetEntity(AllEntities).SetPaging(pager);

        }



        public async Task<EditOrderResult> EditOrder(EditOrderViewModel orderViewModel, IFormFile imageProfile)
        {
            var order = await _orderRepository.GetOrderById(orderViewModel.OrderId);

            if (order == null)
            {
                return EditOrderResult.Fail;
            }


            var imageProfileName = "";

            if (imageProfile?.Length > 0)
            {
                imageProfileName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(imageProfile.FileName);
                imageProfile.AddImageToServer(imageProfileName, FilePath.UploadImageProfileServer, 280, 280);
            }


            order.OrderId = orderViewModel.OrderId;
            order.Description = orderViewModel.Description;
            order.OrderType = orderViewModel.OrderType;
            order.Title = orderViewModel.Title;
            order.PredictDay = orderViewModel.PredictDay;

            //if (!string.IsNullOrEmpty(orderImageName))
            //{
            //    order.imageName = orderImageName;
            //}
            await _orderRepository.UpdateOrder(order);

            await _orderRepository.SaveChange();
            return EditOrderResult.Success;




        }

        public async Task<EditOrderViewModel> GetOrderForEdit(long orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return null;
            }
            var result = new EditOrderViewModel()
            {
                OrderId = order.OrderId,
                Description = order.Description,
                Title = order.Title,
                //IsFinish = order.IsFinish,
                OrderType = order.OrderType
                //IsSale = order.IsSale
            };
            return result;
        }

        public async Task<EditOrderViewModel> FillEditOrderViewModel(long orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return null;
            }
            var user = await _orderRepository.GetOrderById(orderId);
            if (user == null)
            {
                return null;
            }
            var result = new EditOrderViewModel()
            {
                OrderId = order.OrderId,
                Description = order.Description,
                Title = order.Title,
                ImageName = order.ImageName,
                CustomerId = order.CustomerId,
                // IsFinish = order.IsFinish,
                OrderType = order.OrderType,
                PredictDay = order.PredictDay,
                // IsSale = order.IsSale

            };
            return result;
        }

        public async Task<bool> DeleteOrder(long orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return false;
            }
            order.IsDelete = true;
            await _orderRepository.UpdateOrder(order);
            await _orderRepository.SaveChange();

            return true;

        }

        public async Task<AddOrderSelectMarketerResult> AddOrderSelectMarketer(OrderSelectMarketerViewModel marketerViewModel, long userId)
        {
            var order = await _orderRepository.GetOrderById(marketerViewModel.OrderId);
            if (order == null)
            {
                return AddOrderSelectMarketerResult.Fail;
            }

            var selectedMarketerqueryable = await _orderRepository.GetOrderSelectedMarkets();

            if (selectedMarketerqueryable.Any(a => a.OrderId == order.OrderId && !a.IsDelete))
            {
                return AddOrderSelectMarketerResult.SelectedMarketerExist;
            }

            var selectMarketer = new OrderSelectedMarketer()
            {
                Description = marketerViewModel.Description,
                ModifyUserId = userId,
                MarketerId = marketerViewModel.MarketerId,
                OrderId = marketerViewModel.OrderId
            };
            await _orderRepository.AddOrderSelectmarketer(selectMarketer);
            await _orderRepository.SaveChange();

            return AddOrderSelectMarketerResult.Success;
        }

        public async Task<FilterOrderSelectedMarketer> FilterOrderSelectedMarketer(FilterOrderSelectedMarketer filter)
        {
            var query = await _orderRepository.GetOrderSelectedMarkets();


            #region filter

            query = query.Where(a => a.IsDelete);

            if (string.IsNullOrEmpty(filter.FilterCustomerName))
            {
                query = query.Where(a
                    => EF.Functions.Like(a.Order.Customer.User.FirstName, $"%{filter.FilterCustomerName}%") ||
                       EF.Functions.Like(a.Order.Customer.User.LastName, $"%{filter.FilterCustomerName}%") ||
                     EF.Functions.Like(a.Order.Customer.User.FirstName + " " + a.Order.Customer.User.LastName, $"%{filter.FilterCustomerName}%"));


            }
            if (string.IsNullOrEmpty(filter.FilterMarketerName))
            {
                query = query.Where(a => EF.Functions.Like(a.Marketer.User.FirstName + " " + a.Marketer.User.LastName, $"%{filter.FilterMarketerName}%"));

            }
            #endregion

            #region order
            query = query.OrderByDescending(a => a.CreateDate);
            #endregion

            #region paging
            var pager = Pager.build(filter.PageId, filter.AllEntitiesCount, filter.TakeEntity,
             filter.HowManyShowPageAfterAndBefore);

            var AllEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetEntity(AllEntities).SetPaging(pager);


        }

        public async Task<bool> DeleteOrderSelectedMarketer(long orderId)
        {
           var orderSelected = await _orderRepository.GetOrderSelectedMarketerbyId(orderId);
            if (orderSelected == null)
            {
                return false;
            }
            
            await _orderRepository.DeleteOrderSelectedMarketer(orderSelected);
            await _orderRepository.SaveChange();
            return true;
        }

        public async Task<bool> ChangeOrderToFinish(long orderId,long taskId)
        {
            var order = await _orderRepository.GetOrderById(orderId);

            var changeStateResult = await _TaskService.ChangeTaskState(taskId, CrmTaskStatus.Close);

            if (order == null || !changeStateResult)
            {
                return false;
            }
            order.EndDate = DateTime.Now;
            order.IsFinish = true;
            await _orderRepository.UpdateOrder(order);

            await _orderRepository.SaveChange();

            
            return true;
        }
    }
}
