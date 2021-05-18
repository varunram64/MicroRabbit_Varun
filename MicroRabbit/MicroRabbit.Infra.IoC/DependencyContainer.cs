using MediatR;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Domain Bus 
            // This will help us have a single instance of the RabitMQBus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp => 
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
            #endregion

            #region Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            #endregion
        }
    }
}
