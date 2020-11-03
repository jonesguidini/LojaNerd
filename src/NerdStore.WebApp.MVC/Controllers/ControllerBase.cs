using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        // aqui não estamos injetando a interface 'INotificationHandler' pq se fizessemos isso só teriamos acesso ao método Handle()
        // e não teriamos acesso aos outros métodos criados para outros propósitos
        private readonly DomainNotificationHandler _notifications;

        private readonly IMediatorHandler _mediatorHandler;

        // MOCK: substituir esse ClienteId para um id de um cliente logado
        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        // ... mas mesmo não criando a interface aqui é feito um cast pela interface requerida
        protected ControllerBase(INotificationHandler<DomainNotification> notifications, 
                                 IMediatorHandler mediatorHandler)
        {
            // e aqui é necessário um cast explicito para ter acesso aos demais métodos
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        // caso queira notificar novos erros pelas controllers
        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }
    }


}
