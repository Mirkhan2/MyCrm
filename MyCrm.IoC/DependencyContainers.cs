using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
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

            service.AddTransient<IOrderService, OrderService>();
            service.AddTransient<ICompanyService , CompanyService>();


            service.AddTransient<IUserRepository , UserRepository>();
            service.AddTransient<IOrderRepository , OrderRepository>();
            service.AddTransient<ICompanyRepository , CompanyRepository>();
         
        }
    }
}
