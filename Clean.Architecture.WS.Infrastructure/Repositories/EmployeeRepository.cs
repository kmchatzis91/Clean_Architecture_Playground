using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
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

        #region Methods Common
        public async Task<List<Employee>> Get()
        {
            try
            {
                _logger.LogInformation($"Get all employees");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetEmployeesQuery();
                    var employees = await connection.QueryAsync<Employee>(query);

                    if (employees.Count() <= 0 || employees == null)
                    {
                        return new List<Employee>();
                    }

                    return employees.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all employees Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new List<Employee>();
            }
        }

        public async Task<Employee> GetById(long id)
        {
            try
            {
                _logger.LogInformation($"Get employee by id");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetEmployeeByIdQuery(id);
                    var employee = await connection.QueryAsync<Employee>(query);

                    if (employee == null)
                    {
                        return new Employee();
                    }

                    return employee.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get employee by id Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new Employee();
            }
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

        #region Methods Specialized
        public async Task<List<EmployeeView>> GetAllEmployeesInformation()
        {
            try
            {
                _logger.LogInformation($"GetAllEmployeesInformation");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetEmployeesViewQuery();
                    var employees = await connection.QueryAsync<EmployeeView>(query);

                    if (employees.Count() <= 0 || employees == null)
                    {
                        return new List<EmployeeView>();
                    }

                    return employees.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllEmployeesInformation Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new List<EmployeeView>();
            }
        }

        public async Task<EmployeeView> GetEmployeeInformationById(long id)
        {
            try
            {
                _logger.LogInformation($"GetEmployeeInformationById");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetEmployeeByIdViewQuery(id);
                    var employee = await connection.QueryAsync<EmployeeView>(query);

                    if (employee == null)
                    {
                        return new EmployeeView();
                    }

                    return employee.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetEmployeeInformationById Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new EmployeeView();
            }
        }
        #endregion
    }
}
