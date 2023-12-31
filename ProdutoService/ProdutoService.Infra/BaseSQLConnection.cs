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
        private string _connectionString;
        private IDbConnection _connection;
        public IDbConnection Connection
        {
            get
            {
                return _connection ?? new SqlConnection(_connectionString);
            }
        }

        public BaseSQLConnection(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }
    }
}
