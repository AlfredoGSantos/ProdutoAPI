using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Entidades
{
    public class ProdutoRetorno
    {
        public int idProduto { get; set; }
        public string strDescricao { get; set; } = string.Empty;
        public int IdStatus { get; set; }
        public string strDescricaoStatus { get; set; } = string.Empty;
        public DateTime? dtFabricacao { get; set; }
        public DateTime? dtValidade { get; set; }
        public int idFornecedor { get; set; }
        public string strNome { get; set; } = string.Empty;
        public string strCNPJ { get; set; } = string.Empty;
    }
}
