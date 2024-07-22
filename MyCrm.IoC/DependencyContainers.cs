using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyCrm.Application.Interface;
using MyCrm.Application.Services;
using MyCrm.Data.Repository;
using MyCrm.Domain.Interfaces;

namespace MyCrm.IoC
{
    public class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();


            service.AddTransient<IUserRepository , UserRepository>();
         
        }
    }
}
