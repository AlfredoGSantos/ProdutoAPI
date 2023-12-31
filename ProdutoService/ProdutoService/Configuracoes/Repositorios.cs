using ProdutoService.Domain.Interface;
using ProdutoService.Infra.Repositorios;

namespace ProdutoService.Configuracoes
{
    public static class Repositorios
    {
        public static void AddRepositorios(this IServiceCollection services)
        {
            services.AddSingleton<IProdutoRepositorio, ProdutoRepositorio>();
        }
    }
}
