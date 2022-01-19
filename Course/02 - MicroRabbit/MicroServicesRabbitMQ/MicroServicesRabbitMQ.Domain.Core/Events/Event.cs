﻿using System;

namespace MicroServicesRabbitMQ.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        public Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
