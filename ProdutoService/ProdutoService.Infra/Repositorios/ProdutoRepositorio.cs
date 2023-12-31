using Dapper;
using ProdutoService.Domain.Entidades;
using ProdutoService.Domain.Interface;
using ProdutoService.Infra.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Infra.Repositorios
{
    public class ProdutoRepositorio : BaseSQLConnection, IProdutoRepositorio
    {
        public ProdutoRepositorio(string ConnectionString) : base(ConnectionString)
        {
        }

        public Task<int> Editar(ProdutoInput produto)
        {
            throw new NotImplementedException();
        }

        public Task<int> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Inserir(ProdutoInput produto)
        {
            throw new NotImplementedException();
        }

        public async Task<DadosPaginado<ProdutoRetorno>> Listar(ProdutoFiltro filtro)
        {
            IEnumerable<ProdutoRetorno> produtos = new List<ProdutoRetorno>();
            int numeroRegistros = 0;

            using (var conn = Connection)
            {
                conn.Open();
                using (var multi = await conn.QueryMultipleAsync(Produtos_Listar.Query, filtro, commandType: System.Data.CommandType.Text))
                {
                    produtos = multi.Read<ProdutoRetorno>();
                    numeroRegistros = multi.Read<int>().FirstOrDefault();
                }
            }

            return new DadosPaginado<ProdutoRetorno>(numeroRegistros, produtos);
        }

        public async Task<ProdutoRetorno?> Selecionar(int id)
        {
            string query = @"SELECT 
                            	Produto.idProduto,
                            	Produto.strDescricao,
                            	Status.idStatus,
                            	Status.strDescricao AS strDescricaoStatus,
                            	Produto.dtFabricacao,
                            	Produto.dtValidade,
                            	Fornecedor.idFornecedor,
                            	Fornecedor.strNome,
                            	Fornecedor.strCNPJ
                            FROM Produtos.Produtos				Produto				WITH (NOLOCK)
                            INNER JOIN Produtos.Status			Status				WITH (NOLOCK)
                            		ON Status.idStatus			= Produto.idStatus
                            LEFT JOIN Fornecedores.Fornecedores	Fornecedor			WITH (NOLOCK)
                            		ON Fornecedor.idFornecedor	= Produto.idFornecedor
                            WHERE Status.idStatus = 1 AND idProduto = @id";

            using (var conn = Connection)
            {
                conn.Open();
                
                ProdutoRetorno? produto = await conn.QueryFirstOrDefaultAsync<ProdutoRetorno>(query, new { id }, commandType: System.Data.CommandType.Text);

                conn.Close();

                return produto;
            }
        }
    }
}
