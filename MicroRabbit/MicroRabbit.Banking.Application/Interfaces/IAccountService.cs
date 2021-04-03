﻿using MicroRabbit.Banking.Application.ViewModels;
using MicroRabbit.Banking.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void TransferFunds(AccountTransfer accountTransfer);
    }
}
