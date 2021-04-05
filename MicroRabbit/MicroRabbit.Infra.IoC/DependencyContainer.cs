﻿using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.EventHandlers;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
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

            #region Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();
            #endregion

            #region Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            #endregion
        }

        public static void RegisterBankingServices(IServiceCollection services)
        {
            RegisterServices(services);

            #region Application Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion

            #region Data
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<BankingDBContext>();
            #endregion
        }

        public static void RegisterTransferServices(IServiceCollection services)
        {
            RegisterServices(services);

            #region Application Services
            services.AddTransient<ITransferService, TransferService>();
            #endregion

            #region Data
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddTransient<TransferDBContext>();
            #endregion
        }
    }
}
