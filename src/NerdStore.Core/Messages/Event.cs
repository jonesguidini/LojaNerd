using System;
using MediatR;

namespace NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get; set; } // o horario que o evento ocorreu

        protected Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
