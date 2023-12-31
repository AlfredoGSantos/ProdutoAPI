using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Entidades
{
    public class Paginacao
    {
        public int Pagina { get; set; }
        public int ItensPagina { get; set; }
        public string? OrdenarPor { get; set; }
        public bool OrdenacaoCrescente { get; set; }
    }
}
