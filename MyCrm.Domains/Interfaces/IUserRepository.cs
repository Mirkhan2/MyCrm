using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Account;
using MyCrm.Domains.ViewModels.User;

namespace MyCrm.Domains.Interfaces
{
    public interface IUserRepository
    {
        Task<FilterUserViewModel> FilterUser(FilterUserViewModel filter);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(long userId);
        Task SaveChangeAsync();
        Task<User> GetUserDetailById(long userId);
        Task<Marketer> GetMarketerById(long marketerId);
        Task AddMarketer(Marketer marketer);
        Task UpdateMarketer(Marketer marketer);

        Task AddCustomer(Customer customer);
        Task<Customer> GetCustomerbyId(long customerId);

        Task UpdateCustomer(Customer customer);
        //Task<List<Marketer>> GetMarketerLsit();
        Task<IQueryable<Marketer>> GetMarketerQueryable();
        Task<IQueryable<User>> GetUserQueryable();
    }
}
