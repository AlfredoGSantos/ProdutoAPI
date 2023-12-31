using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Services.Comandos
{
    public class ExcluirComando : IRequest<object>
    {
        public int CodigoProduto { get; set; }
    }
}
