using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Data.Context;
using MyCrm.Domains.Entities.Account;
using MyCrm.Domains.Entities.Orders;
using MyCrm.Domains.Interfaces;
using MyCrm.Domains.ViewModels.Paging;
using MyCrm.Domains.ViewModels.User;

namespace MyCrm.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        #region ctor
        private readonly CrmContext _context;

        public UserRepository(CrmContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<FilterUserViewModel> FilterUser (FilterUserViewModel filter)
        {
           
            var query = _context.Users
             .OrderByDescending(a => a.CreateDate)
             .Include(a => a.Marketer)
             .Include(a => a.Customer)
             .Where(a => !a.IsDelete)
             .AsQueryable();
            #region filter

            if (!string.IsNullOrEmpty(filter.FilterLastName))
            {
                query = query.Where(a => EF.Functions.Like(a.LastName, $"%{filter.FilterLastName}"));
            }

            if (!string.IsNullOrEmpty(filter.FilterFirstName))
            {
                query = query.Where(a => EF.Functions.Like(a.FirstName, $"%{filter.FilterFirstName}"));
            }

            if (!string.IsNullOrEmpty(filter.FilterMobile))
            {
                query = query.Where(a => EF.Functions.Like(a.MobilePhone, $"%{filter.FilterMobile}"));
            }

            #endregion

            #region paging

            var pager = Pager.build(filter.PageId, filter.AllEntitiesCount, filter.TakeEntity,
                filter.HowManyShowPageAfterAndBefore);

            var AllEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetEntity(AllEntities).SetPaging(pager);

        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public async Task<User> GetUserById(long userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddMarketer(Marketer marketer)
        {
            await _context.Marketers.AddAsync(marketer);
        }

        public async Task UpdateMarketer(Marketer marketer)
        {
            _context.Marketers.Update(marketer);
        }

        public async Task<User> GetUserDetailById(long userId)
        {
            return await _context.Users
                .Include(a =>a.Marketer)
                .Include(a => a.Customer)
                .FirstOrDefaultAsync(a => a.UserId == userId);
        }

        public async Task<Marketer> GetMarketerById(long marketerid)
        {
           return await _context.Marketers.SingleOrDefaultAsync(a => a.UserId == marketerid);
        }

        public async Task AddCustomer(Customer customer)
        {
            _context.Customers.AddAsync(customer);
        }

        public async Task<Customer> GetCustomerbyId(long customerId)
        {
            return await _context.Customers
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.UserId == customerId);
        }

        public async Task UpdateCustomer(Customer customer)
        {
             _context.Customers.Update(customer);
        }

        public async Task AddOrderSelectMarketer(OrderSelectedMarketer orderSelectedMarketer)
        {
            await _context.OrderSelectedMarketers.AddAsync(orderSelectedMarketer);
        }

        public async Task<IQueryable<OrderSelectedMarketer>> GetOrderSelectMarketer()
        {
            return _context.OrderSelectedMarketers.AsQueryable();
        }


        public async Task<IQueryable<Marketer>> GetMarketerQueryable()
        {
            return _context.Marketers.Include(a => a.User).AsQueryable();
        }

        public async Task<IQueryable<User>> GetUserQueryable()
        {
            return _context.Users.AsQueryable();
        }
    }
}
