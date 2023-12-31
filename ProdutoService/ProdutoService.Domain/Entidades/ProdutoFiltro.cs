using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Entidades
{
    public class ProdutoFiltro : Paginacao
    {
        public int? CodigoProduto { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string? Descricao { get; set; }
        public string? DescricaoFornecedor { get; set; }
    }
}
