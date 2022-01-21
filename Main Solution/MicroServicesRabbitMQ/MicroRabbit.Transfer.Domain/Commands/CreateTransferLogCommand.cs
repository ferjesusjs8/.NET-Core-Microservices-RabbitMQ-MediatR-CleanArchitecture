namespace MicroRabbit.Transfer.Domain.Commands
{
    public class CreateTransferLogCommand : TransferLogCommand
    {
        public CreateTransferLogCommand(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}
