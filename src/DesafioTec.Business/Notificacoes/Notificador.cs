using DesafioTec.Business.Interfaces;

namespace DesafioTec.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes; // ARMAZENA NOTIFICACOES DURANTE TODO REQUEST

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool PossuiNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
