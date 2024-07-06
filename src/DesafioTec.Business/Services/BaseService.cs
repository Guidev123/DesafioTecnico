using DesafioTec.Business.Interfaces;
using DesafioTec.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }
        protected void Notificar(string menssagemErro)
        {
            _notificador.AdicionarNotificacao(new Notificacao(menssagemErro));
        }

        protected bool ValidarEntidade<TValidation, TEntity>(TValidation validacao, TEntity entidade) where TValidation : AbstractValidator<TEntity>
        {
            var validator = validacao.Validate(entidade);

            if(validator.IsValid) return true;

            Notificar(validator);
            return false;   
        }
    }
}
