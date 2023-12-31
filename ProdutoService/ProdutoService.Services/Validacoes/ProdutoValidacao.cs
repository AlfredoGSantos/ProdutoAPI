using FluentValidation;
using ProdutoService.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Services.Validacoes
{
    public class ProdutoValidacao : AbstractValidator<Produto>
    {
        public ProdutoValidacao()
        {
            RuleFor(x => x.Descricao).NotNull().NotEmpty().WithMessage("Faltando a descrição do produto");
            RuleFor(x => x).Custom(ValidacaoDatas);
        }

        private void ValidacaoDatas(Produto produto, ValidationContext<Produto> context)
        {
            if (!produto.DataFabricacao.HasValue && produto.DataValidade.HasValue)
                context.AddFailure("Data de fabricação não informada.");

            if (produto.DataFabricacao.HasValue && produto.DataValidade.HasValue)
            {
                if (produto.DataFabricacao.Value >= produto.DataValidade.Value)
                    context.AddFailure("Data de fabricação não pode ser maior ou igual a data de validade.");
            }
        }
    }
}
