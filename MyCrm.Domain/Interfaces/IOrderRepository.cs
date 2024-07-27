using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Orders;

namespace MyCrm.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(long orderId);
        Task AddOrder(Order order);

        Task SaveChange();

        Task UpdateOrder(Order order);

        //Task DeleteOrder(long orderId);
    }
}
