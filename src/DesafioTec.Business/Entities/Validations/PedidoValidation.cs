using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Entities.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
            RuleFor(p => p.DataPedido).NotEmpty().WithMessage("Por favor, forneça uma data para o pedido");

            RuleFor(p => p.ValorTotal).NotEmpty().WithMessage("Por favor, forneça um valor total para o pedido");

        }
    }
}
