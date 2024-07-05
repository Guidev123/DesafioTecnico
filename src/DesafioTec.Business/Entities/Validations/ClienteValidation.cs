using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Entities.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(100)
                .MinimumLength(2)
                .WithMessage("O campo {PropertyName} está em formato inválido");

            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Forneça um email válido");
        }
    }
}
