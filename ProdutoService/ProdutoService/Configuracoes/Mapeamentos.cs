using ProdutoService.Domain.Mapeamentos;
using ProdutoService.Services.Mapeamentos;

namespace ProdutoService.Configuracoes
{
    public static class Mapeamentos
    {
        public static void AddMap(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProdutoMap));
            services.AddAutoMapper(typeof(CommandMap));
        }
    }
}
