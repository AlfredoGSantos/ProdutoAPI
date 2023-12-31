using ProdutoService.Domain.Interface;
using ProdutoService.Infra.Repositorios;

namespace ProdutoService.Configuracoes
{
    public static class Repositorios
    {
        public static void AddRepositorios(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IProdutoRepositorio>(new ProdutoRepositorio(connectionString));
        }
    }
}
