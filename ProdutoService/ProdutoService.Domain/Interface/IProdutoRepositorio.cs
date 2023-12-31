using ProdutoService.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Interface
{
    public interface IProdutoRepositorio
    {
        Task<DadosPaginado<ProdutoRetorno>> Listar(ProdutoFiltro filtro);
        Task<ProdutoRetorno?> Selecionar(int id);
        Task<int> Inserir(ProdutoInput produto);
        Task<int> Editar(ProdutoInput produto);
        Task<int> Excluir(int id);
    }
}
