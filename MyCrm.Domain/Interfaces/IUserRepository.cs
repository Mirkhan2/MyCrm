using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Account;
using MyCrm.Domain.ViewModels.User;

namespace MyCrm.Domain.Interfaces
{
    public  interface IUserRepository
    {
        Task<FilterUserViewModel> FilterUser(FilterUserViewModel filter);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<User> GetUserById(long userId);
        Task SaveChangeAsync();
        Task<User> GetUserDetailById(long userId);
        Task<Marketer> GetMarketerById(long marketerid);
        Task AddMarketer(Marketer marketer);
        Task UpdateMarketer(Marketer marketer);

        Task AddCustomer (Customer customer);
        Task<Customer> GetCustomerbyId(long customerId);

        Task UpdateCustomer(Customer customer);

    }
}
