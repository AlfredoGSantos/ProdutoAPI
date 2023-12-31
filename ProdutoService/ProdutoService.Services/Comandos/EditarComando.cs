﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Services.Comandos
{
    public class EditarComando : IRequest<object>
    {
        public int CodigoProduto { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
    }
}
