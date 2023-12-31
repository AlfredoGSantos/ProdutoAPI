using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Entidades
{
    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
    }

    public class ProdutoRetorno
    {
        public int idProduto { get; set; }
        public string strDescricao { get; set; } = string.Empty;
        public int IdStatus { get; set; }
        public string strDescricaoStatus { get; set; } = string.Empty;
        public DateTime? dtFabricacao { get; set; }
        public DateTime? dtValidade { get; set; }
        public int idFornecedor { get; set; }
        public string strNome { get; set; }
        public string strCNPJ { get; set; }
    }
}
