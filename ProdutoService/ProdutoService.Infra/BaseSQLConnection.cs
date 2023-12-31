using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoService.Infra
{
    public class BaseSQLConnection
    {
        private IDbConnection _connection;
        public IDbConnection Connection => _connection;

        public BaseSQLConnection(string ConnectionString)
        {
            _connection = new SqlConnection(ConnectionString);
        }
    }
}
