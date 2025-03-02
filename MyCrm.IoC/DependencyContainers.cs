using Microsoft.Extensions.DependencyInjection;
using MyCrm.Application.Interface;
using MyCrm.Application.Interfaces;
using MyCrm.Application.Services;
using MyCrm.Data.Repository;
using MyCrm.Domains.Interfaces;

namespace MyCrm.IoC
{
    public class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
            service.AddTransient<IOrderService, OrderService>();
            service.AddTransient<ICompanyService, CompanyService>();
            service.AddTransient<IProgramSetting, ProgramSetting>();
            service.AddTransient<IEventService, EventService>();
            service.AddTransient<ILeadService, LeadService>();
            service.AddTransient<ITaskService, TaskService>();
            service.AddTransient<IPredictService, PredictService>();



            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<ICompanyRepository, CompanyRepository>();
            service.AddTransient<IEventRepository, EventRepository>();
            service.AddTransient<ILeadRepository, LeadRepository>();
            service.AddTransient<ITaskRepository, TaskRepository>();
            service.AddTransient<IPredictRepository, PredictRepository>();
        }
    }
}
