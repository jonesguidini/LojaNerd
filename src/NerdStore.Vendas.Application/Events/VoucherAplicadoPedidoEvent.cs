using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class VoucherAplicadoPedidoEvent : Event
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid VoucherId { get; private set; }

        public VoucherAplicadoPedidoEvent(Guid clienteId, Guid pedidoId, Guid voucherId)
        {
            AggregateId = pedidoId; // informa qual a raiz de agregação (subclasse Mensagem de Event)
            ClienteId = clienteId;
            PedidoId = pedidoId;
            VoucherId = voucherId;
        }
    }
}