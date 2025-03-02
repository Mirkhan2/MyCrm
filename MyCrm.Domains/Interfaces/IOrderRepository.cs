using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Orders;

namespace MyCrm.Domains.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(long orderId);
        Task AddOrder(Order order);

        Task SaveChange();

        Task UpdateOrder(Order order);
        Task<IQueryable<Order>> GetOrders();

        Task DeleteOrder(long orderId);

        Task AddOrderSelectmarketer(OrderSelectedMarketer orderSelectedMarketer);

        Task<IQueryable<OrderSelectedMarketer>> GetOrderSelectedMarkets();
        Task<OrderSelectedMarketer> GetOrderSelectedMarketerbyId(long orderId);
        Task UpdateOrderSelectedMarketer(OrderSelectedMarketer orderSelectedMarketer);
        Task DeleteOrderSelectedMarketer(OrderSelectedMarketer orderSelectedMarketer);

    }
}
