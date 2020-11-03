using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Events
{
    public class PedidoItemAdicionadoEvent : Event
    {
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Guid PedidoId { get; private set; }
        public string NomeProduto { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public int Quantidade { get; private set; }

        public PedidoItemAdicionadoEvent(Guid clienteId, Guid produtoId, Guid pedidoId, string nomeProduto, decimal valorUnitario, int quantidade)
        {
            AggregateId = pedidoId; // informa qual a raiz de agregação (subclasse Mensagem de Event)
            ClienteId = clienteId;
            ProdutoId = produtoId;
            PedidoId = pedidoId;
            ValorUnitario = valorUnitario;
            Quantidade = quantidade;
            NomeProduto = nomeProduto;
        }
    }
}