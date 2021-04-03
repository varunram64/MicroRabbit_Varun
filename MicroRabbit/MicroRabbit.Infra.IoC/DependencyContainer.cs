using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Domain Bus 
            services.AddTransient<IEventBus, RabbitMQBus>();
            #endregion

            #region Application Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion

            #region Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            #endregion
        }
    }
}
