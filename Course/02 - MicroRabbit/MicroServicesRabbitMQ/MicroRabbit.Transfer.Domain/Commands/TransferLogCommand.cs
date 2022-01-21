using MicroServicesRabbitMQ.Domain.Core.Commands;

namespace MicroRabbit.Transfer.Domain.Commands
{
    public abstract class TransferLogCommand : Command
    {
        public int From { get; protected set; }
        public int To { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
