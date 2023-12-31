using AutoMapper;
using MediatR;
using ProdutoService.Domain.Entidades;
using ProdutoService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Services.Queries
{
    public class SelecionarProdutoQueryHandler : IRequestHandler<SelecionarProdutoQuery, Produto>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public SelecionarProdutoQueryHandler(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }
        public async Task<Produto> Handle(SelecionarProdutoQuery request, CancellationToken cancellationToken)
        {
            ProdutoRetorno? produtoRetorno = await _produtoRepositorio.Selecionar(request.CodigoProduto);

            if (produtoRetorno != null)
            {
                var produto = _mapper.Map<Produto>(produtoRetorno);

                return produto;
            }

            return new Produto();
        }
    }
}
