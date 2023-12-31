using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Entidades
{
    public class DadosPaginado<T>
    {
        public int NumeroRegistros { get; set; }
        public IEnumerable<T> Itens { get; set; } = Enumerable.Empty<T>();

        public DadosPaginado()
        {
        }

        public DadosPaginado(int NumeroRegistros, IEnumerable<T> Itens)
        {
            this.NumeroRegistros = NumeroRegistros;
            this.Itens = Itens;
        }
    }
}
