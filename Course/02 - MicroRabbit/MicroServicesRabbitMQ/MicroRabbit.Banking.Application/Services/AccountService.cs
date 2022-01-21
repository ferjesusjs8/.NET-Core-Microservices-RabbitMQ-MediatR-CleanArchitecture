using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroServicesRabbitMQ.Domain.Core.Bus;
using System;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository repository, IEventBus eventBus)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _repository.GetAccounts();
        }

        public string Transfer(AccountTransfer accountTransfer)
        {
            var account = _repository.GetById(accountTransfer.FromAccount);

            if (account.AccountBalance >= accountTransfer.TransferAmount)
            {
                try
                {
                    account.AccountBalance -= accountTransfer.TransferAmount;

                    var createTransferCommand = new CreateTransferCommand(
                        accountTransfer.FromAccount,
                        accountTransfer.ToAccount,
                        accountTransfer.TransferAmount);

                    _eventBus.SendCommand(createTransferCommand);

                    _repository.Update(account);

                    return $"Transaction completed successfully your new account balance is: {account.AccountBalance}.";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                return "Insuficient balance for this transfer!";
            }
        }
    }
}
