using DesafioTec.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Interfaces
{
    public interface INotificador
    {
        bool PossuiNotificacao();
        List<Notificacao> ObterNotificacoes();
        void ArmazenaNotificacao(Notificacao notificacao);
    }
}
