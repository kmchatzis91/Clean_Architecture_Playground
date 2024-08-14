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
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public async Task<bool> Add(Employee employee)
        {
            try
            {
                _logger.LogInformation($"Add employee: {JsonConvert.SerializeObject(employee)}");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();

                    // input -> FirstName
                    parameters.Add("FirstName", employee.FirstName,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> LastName
                    parameters.Add("LastName", employee.LastName,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> Email
                    parameters.Add("Email", employee.Email,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> PhoneNumber
                    parameters.Add("PhoneNumber", employee.PhoneNumber,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> RoleId
                    parameters.Add("RoleId", employee.RoleId,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    // input -> CompanyId
                    parameters.Add("CompanyId", employee.CompanyId,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    var result = await connection.ExecuteAsync("INSERT_EMPLOYEE", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add employee Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> Update(Employee employee)
        {
            try
            {
                _logger.LogInformation($"Update employee: {JsonConvert.SerializeObject(employee)}");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();

                    // input -> EmployeeId
                    parameters.Add("EmployeeId", employee.EmployeeId,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    // input -> FirstName
                    parameters.Add("FirstName", employee.FirstName,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> LastName
                    parameters.Add("LastName", employee.LastName,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> Email
                    parameters.Add("Email", employee.Email,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> PhoneNumber
                    parameters.Add("PhoneNumber", employee.PhoneNumber,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    // input -> RoleId
                    parameters.Add("RoleId", employee.RoleId,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    // input -> CompanyId
                    parameters.Add("CompanyId", employee.CompanyId,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    var result = await connection.ExecuteAsync("UPDATE_EMPLOYEE", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update employee Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> DeleteById(long id)
        {
            try
            {
                _logger.LogInformation($"Delete employee id: {id}");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();

                    // input -> EmployeeId
                    parameters.Add("EmployeeId", id,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    var result = await connection.ExecuteAsync("DELETE_EMPLOYEE", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete employee Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return false;
            }
        }
        #endregion

        #region Methods Specialized
        public async Task<List<EmployeeView>> GetView()
        {
            try
            {
                _logger.LogInformation($"GetView employee");

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
                _logger.LogError($"GetView employee Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new List<EmployeeView>();
            }
        }

        public async Task<EmployeeView> GetViewById(long id)
        {
            try
            {
                _logger.LogInformation($"GetViewById employee, id: {id}");

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
                _logger.LogError($"GetViewById employee Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new EmployeeView();
            }
        }
        #endregion
    }
}
