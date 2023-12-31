using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Entidades
{
    public class ProdutoInput
    {
        public int? IdProduto { get; set; }
        public string strDescricao { get; set; } = string.Empty;
        public int idStatus { get; set; }
        public DateTime? dtFabricao { get; set; }
        public DateTime? dtValidade { get; set; }
        public int idFornecedor { get; set; }
    }
}
