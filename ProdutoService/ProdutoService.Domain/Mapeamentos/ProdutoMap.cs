using AutoMapper;
using ProdutoService.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain.Mapeamentos
{
    public class ProdutoMap : Profile
    {
        public ProdutoMap()
        {
            CreateMap<ProdutoRetorno, Produto>()
                .ForMember(d => d.CodigoProduto, m => m.MapFrom(s => s.idProduto))
                .ForMember(d => d.Descricao, m => m.MapFrom(s => s.strDescricao))
                .ForMember(d => d.Situacao, m => m.MapFrom(s => s.strDescricaoStatus))
                .ForMember(d => d.DataFabricacao, m => m.MapFrom(s => s.dtFabricacao))
                .ForMember(d => d.DataValidade, m => m.MapFrom(s => s.dtValidade))
                .ForMember(d => d.CodigoFornecedor, m => m.MapFrom(s => s.idFornecedor))
                .ForMember(d => d.DescricaoFornecedor, m => m.MapFrom(s => s.strNome))
                .ForMember(d => d.CNPJ, m => m.MapFrom(s => s.strCNPJ));

            CreateMap<Produto, ProdutoInput>()
                .ForMember(d => d.IdProduto, m => m.MapFrom(s => s.CodigoProduto))
                .ForMember(d => d.strDescricao, m => m.MapFrom(s => s.Descricao))
                .ForMember(d => d.idStatus, m => m.MapFrom(s => 1))
                .ForMember(d => d.dtFabricao, m => m.MapFrom(s => s.DataFabricacao))
                .ForMember(d => d.dtValidade, m => m.MapFrom(s => s.DataValidade))
                .ForMember(d => d.idFornecedor, m => m.MapFrom(s => s.CodigoFornecedor));
        }
    }
}
