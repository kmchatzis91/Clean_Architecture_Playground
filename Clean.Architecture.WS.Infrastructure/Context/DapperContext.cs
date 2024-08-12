using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Context
{
    public class DapperContext
    {
        #region Fields & Properties
        private readonly IConfiguration _configuration;
        private readonly string? _connectionString;
        #endregion

        #region Constructor
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MssqlDbConnectionString");
        }
        #endregion

        #region Methods
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
        #endregion
    }
}
