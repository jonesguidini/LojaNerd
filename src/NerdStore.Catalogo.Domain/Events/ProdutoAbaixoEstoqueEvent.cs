﻿using NerdStore.Core.DomainObjects;
using System;
using NerdStore.Core.Messages.CommonMessages.DomainEvents;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get; set; }

        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
