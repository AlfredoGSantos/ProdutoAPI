using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Domain
{
    public static class CustomConfig
    {
        public static string? ConnectionString => Environment.GetEnvironmentVariable("ConnectionString");
    }
}
