using MicroServicesRabbitMQ.Domain.Core.Events;
using System;

namespace MicroServicesRabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        public Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
