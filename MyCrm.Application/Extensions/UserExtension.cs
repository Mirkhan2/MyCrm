﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MyCrm.Domains.Entities.Account;

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

        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
                if (data !=null)
                {
                    return Convert.ToInt64(data?.Value);
                }
                return 0;
            }
            return 0;
        }
    }
}
