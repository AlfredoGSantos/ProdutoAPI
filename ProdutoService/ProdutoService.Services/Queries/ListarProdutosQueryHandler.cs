using AutoMapper;
using MediatR;
using ProdutoService.Domain.Entidades;
using ProdutoService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Services.Queries
{
    public class ListarProdutosQueryHandler : IRequestHandler<ListarProdutosQuery, DadosPaginado<Produto>>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ListarProdutosQueryHandler(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }
        public async Task<DadosPaginado<Produto>> Handle(ListarProdutosQuery request, CancellationToken cancellationToken)
        {
            var listaRetorno = await _produtoRepositorio.Listar(request);
            var lista = new List<Produto>();

            lista.AddRange(listaRetorno.Itens.Select(x => _mapper.Map<Produto>(x)));

            return new DadosPaginado<Produto>(listaRetorno.NumeroRegistros, lista);
        }
    }
}
