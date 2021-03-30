using System;

namespace MicroRabbit.Domain.Core.Events
{
    public abstract class Event
    {
        public DateTime timeStamp { get; protected set; }

        protected Event()
        {
            timeStamp = DateTime.Now;
        }
    }
}
