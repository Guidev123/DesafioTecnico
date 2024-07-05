using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Notificacoes
{
    public class Notificacao
    {
        public Notificacao(string menssagem)
        {
            Menssagem = menssagem;
        }
        public string Menssagem { get; }
    }
}
