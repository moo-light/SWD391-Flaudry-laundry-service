using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Application.Utils;
using Infrastructures.Mappers;
using Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBatchService, BatchService>();
            services.AddScoped<IBatchRepository, BatchRepository>();

            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();

            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverService, DriverService>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetail, OrderDetailService>(); 

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IOrderInBatchRepository, OrderInBatchRepository>();
            services.AddScoped<IOrderInBatchService, OrderInBatchService>();
            

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<IDriverService, DriverService>();
            
            services.AddScoped<IBaseUserRepository, BaseUserRepository>();
            services.AddScoped<IBaseUserService, BaseUserService>();

            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionService, SessionService>();

            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceService, ServiceService>();

            //   services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IUserService, UserService>();

            services.AddSingleton<ICurrentTime, CurrentTime>();

            // ATTENTION: if you do migration please check file README.md
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(databaseConnection).EnableSensitiveDataLogging());
            // this configuration just use in-memory for fast develop

            services.AddAutoMapper(typeof(MapperConfigurationsProfile),typeof(CustomerMapperProfile));

            return services;
        }
    }
}
