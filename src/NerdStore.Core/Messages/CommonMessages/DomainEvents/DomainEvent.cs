using System;
using MediatR;

namespace NerdStore.Core.Messages.CommonMessages.DomainEvents
{
    public abstract class DomainEvent : Message, INotification
    {
        public DateTime TimeStamp { get; set; } // o horario que o evento ocorreu

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            TimeStamp = DateTime.Now;
        }
    }
}
