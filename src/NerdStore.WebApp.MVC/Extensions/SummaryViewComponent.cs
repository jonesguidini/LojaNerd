using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Extensions
{
    /// <summary>
    /// Componente responsável por tratar e lançar as notificações no ModelState
    /// </summary>
    public class SummaryViewComponent : ViewComponent
    {

        private readonly DomainNotificationHandler _notifications;

        public SummaryViewComponent(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notifications.ObterNotificacoes());

            // adiciona as notificações no ModelState
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Value));

            // ver view no 'shared/Components/Summary'
            // adicionar ref dessa view em '_viewImports.cshtml'
            return View();
        }
    }
}