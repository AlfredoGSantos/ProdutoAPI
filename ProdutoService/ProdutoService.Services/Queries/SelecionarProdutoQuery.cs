using MediatR;
using ProdutoService.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Services.Queries
{
    public class SelecionarProdutoQuery : IRequest<Produto>
    {
        public int CodigoProduto { get; set; }
    }
}
