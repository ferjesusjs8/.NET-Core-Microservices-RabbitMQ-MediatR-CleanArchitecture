using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Transfer.Domain.Commands;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using MicroServicesRabbitMQ.Domain.Core.Bus;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly ITransferRepository _repository;

        public TransferEventHandler(IEventBus eventBus, ITransferRepository repository)
        {
            _eventBus = eventBus;
            _repository = repository;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            var createTransferLogCommand = new CreateTransferLogCommand(@event.From, @event.To, @event.Amount);

            var transferLog = new TransferLog()
            {
                Amount = @event.Amount,
                FromAccount = @event.From,
                ToAccount = @event.To
            };

            _repository.Add(transferLog);

            _eventBus.SendCommand(createTransferLogCommand);

            return Task.CompletedTask;
        }
    }
}
