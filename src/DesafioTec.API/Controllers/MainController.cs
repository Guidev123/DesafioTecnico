using DesafioTec.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTec.API.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.PossuiNotificacao();
        }
    }
}
