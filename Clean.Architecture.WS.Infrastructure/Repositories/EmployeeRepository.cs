using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Core.Entities;
using Clean.Architecture.WS.Infrastructure.Context;
using Clean.Architecture.WS.Sql.Queries;
using Clean.Architecture.WS.Sql.Scripts;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Fields & Properties
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly DapperContext _dapperContext;
        #endregion

        #region Constructor
        public EmployeeRepository(ILogger<EmployeeRepository> logger, DapperContext dapperContext)
        {
            _logger = logger;
            _dapperContext = dapperContext;
        }
        #endregion

        #region Methods
        public async Task<List<Employee>> Get()
        {
            try
            {
                _logger.LogInformation($"Get all employees");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetEmployeesQuery();
                    var fileDetails = await connection.QueryAsync<Employee>(query);

                    if (fileDetails.Count() <= 0 || fileDetails == null)
                    {
                        return new List<Employee>();
                    }

                    return fileDetails.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all employees Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new List<Employee>();
            }
        }

        public Task<Employee> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
