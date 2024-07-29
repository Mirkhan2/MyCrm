using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Domain.Entities.Orders;
using MyCrm.Domain.Interfaces;

namespace MyCrm.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        #region ctor
        private readonly CrmContext _context;
        public OrderRepository(CrmContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<Order> GetOrderById(long orderId)
        {
            return await _context.Orders.FirstOrDefaultAsync(a => a.OrderId == orderId);
      
        }

        public async Task AddOrder(Order order)
        {
             await _context.AddAsync(order);


        }

        public async Task SaveChange()
        {
           await _context.SaveChangesAsync();

        }

        public async Task UpdateOrder(Order order)
        {

             _context.Orders.Update(order);
        }

        public async Task<IQueryable<Order>> GetOrders()
        {
            //lazyloading*
           return  _context.Orders
                .Include(a => a.Customer)
                .ThenInclude(a => a.User)
                .AsQueryable();
        }

        public Task DeleteOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        public async Task AddOrderSelectmarketer(OrderSelectedMarketer orderSelectedMarketer)
        {
           await _context.OrderSelectedMarketers.AddAsync(orderSelectedMarketer);

        }

        public Task<IQueryable<OrderSelectedMarketer>> GetOrderSelectedMarkets()
        {
            throw new NotImplementedException();
        }

        //public async Task<IQueryable<OrderSelectedMarketer>> GetOrderSelectedMarkets()
        //{
        //    return await _context.OrderSelectedMarketers.AsQueryable();
        //}

        //public await Task<IQueryable<OrderSelectedMarketer>> GetOrderSelectedMarkets()
        //{
        //    return _context.OrderSelectedMarketers.AsQueryable();
        //}
        //public async Task UpdateOrder
    }
}
