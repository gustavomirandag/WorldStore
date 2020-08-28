using System;
using System.Collections.Generic;
using System.Text;

namespace WorldStore.Common.Application.Interfaces.CQRS.Events
{
    public abstract class Event
    {
        public abstract string QueueName { get; }
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = new DateTime();
        }
    }
}
