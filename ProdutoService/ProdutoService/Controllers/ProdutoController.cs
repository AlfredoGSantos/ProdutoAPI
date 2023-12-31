using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutoService.Services.Comandos;
using ProdutoService.Services.Queries;

namespace ProdutoService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProdutoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<object> Listar([FromQuery]ListarProdutosQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Selecionar(int id)
        {
            return Ok(await _mediator.Send(new SelecionarProdutoQuery() { CodigoProduto = id }));
        }

        [HttpPost]
        public async Task<object> Inserir([FromBody]InserirComando comando)
        {
            return Ok(await _mediator.Send(comando));
        }

        [HttpPatch]
        public async Task<object> Editar([FromBody]EditarComando comando)
        {
            return Ok(await _mediator.Send(comando));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Excluir(int id)
        {
            return Ok(await _mediator.Send(new ExcluirComando() { CodigoProduto = id }));
        }
    }
}
