
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.Interfaces;
using MyCrm.Domain.ViewModels.Paging;
using MyCrm.Domain.ViewModels.User;

namespace MyCrm.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CrmContext _context;

        public UserRepository(CrmContext context)
        {
            _context = context;
        }

        public async Task<FilterUserViewModel> FilterUser (FilterUserViewModel filter)
        {
            var query = _context.Users.AsQueryable();

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
                filter.HowManyShowPageafterAndBefore);

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
            _context.Cursomers.AddAsync(customer);
        }

        public async Task<Customer> GetCustomerbyId(long customerId)
        {
            return await _context.Cursomers.FirstOrDefaultAsync(a => a.UserId == customerId);
        }

        public async Task UpdateCustomer(Customer customer)
        {
             _context.Cursomers.Update(customer);
        }
    }
}
