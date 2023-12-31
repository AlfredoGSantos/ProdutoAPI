using AutoMapper;
using ProdutoService.Domain.Entidades;
using ProdutoService.Services.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Services.Mapeamentos
{
    public class CommandMap : Profile
    {
        public CommandMap()
        {
            CreateMap<InserirComando, Produto>();
            CreateMap<EditarComando, Produto>();
        }
    }
}
