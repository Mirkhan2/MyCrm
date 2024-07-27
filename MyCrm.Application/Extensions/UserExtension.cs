using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domain.Entities.Account;

namespace MyCrm.Application.Extensions
{
    public static class UserExtension
    {
        public static string GetUserShowName(this User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
            {
                return $"{user.FirstName} {user.LastName}";
            }
            return user.MobilePhone ;
        }
    }
}
