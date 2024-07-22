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


        Task AddMarketer(Marketer marketer);
        Task UpdateMarketer(Marketer marketer);
    }
}
