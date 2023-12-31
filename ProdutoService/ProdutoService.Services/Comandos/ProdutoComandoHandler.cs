using AutoMapper;
using FluentValidation;
using MediatR;
using ProdutoService.Domain.Entidades;
using ProdutoService.Domain.Interface;
using ProdutoService.Services.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProdutoService.Services.Comandos
{
    public class ProdutoComandoHandler : IRequestHandler<InserirComando, object>, IRequestHandler<EditarComando, object>,
        IRequestHandler<ExcluirComando, object>
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoComandoHandler(IProdutoRepositorio produtoRepositorio, IMapper mapper)
        {
            _produtoRepositorio = produtoRepositorio;
            _mapper = mapper;
        }
        public async Task<object> Handle(InserirComando request, CancellationToken cancellationToken)
        {
            var produto = _mapper.Map<Produto>(request);
            new ProdutoValidacao().ValidateAndThrow(produto);

            var produtoInput = _mapper.Map<ProdutoInput>(produto);

            var codigoProduto = await _produtoRepositorio.Inserir(produtoInput);

            return new { codigoProduto };
        }

        public async Task<object> Handle(EditarComando request, CancellationToken cancellationToken)
        {
            var produto = _mapper.Map<Produto>(request);
            new ProdutoValidacao().ValidateAndThrow(produto);

            var produtoInput = _mapper.Map<ProdutoInput>(produto);

            return await _produtoRepositorio.Editar(produtoInput);
        }

        public async Task<object> Handle(ExcluirComando request, CancellationToken cancellationToken)
        {
            return await _produtoRepositorio.Excluir(request.CodigoProduto);
        }
    }
}
