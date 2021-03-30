using MicroRabbit.Domain.Core.Events;
using System;

namespace MicroRabbit.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime timeStamp { get; protected set; }

        protected Command()
        {
            timeStamp = DateTime.Now;
        }
    }
}
