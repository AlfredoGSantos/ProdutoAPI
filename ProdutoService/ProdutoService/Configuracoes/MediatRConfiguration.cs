using ProdutoService.Services.Comandos;
using ProdutoService.Services.Queries;

namespace ProdutoService.Configuracoes
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(SelecionarProdutoQuery).Assembly));
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ListarProdutosQuery).Assembly));
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(InserirComando).Assembly));
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(EditarComando).Assembly));
            services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ExcluirComando).Assembly));
        }
    }
}
