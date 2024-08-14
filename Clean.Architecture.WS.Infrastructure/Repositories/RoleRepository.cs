using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Infrastructure.Context;
using Clean.Architecture.WS.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        #region Fields & Properties
        private readonly ILogger<RoleRepository> _logger;
        private readonly DapperContext _dapperContext;
        #endregion

        #region Constructor
        public RoleRepository(ILogger<RoleRepository> logger, DapperContext dapperContext)
        {
            _logger = logger;
            _dapperContext = dapperContext;
        }
        #endregion

        #region Methods Common
        public async Task<List<Role>> Get()
        {
            try
            {
                _logger.LogInformation($"Get all roles");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetRolesQuery();
                    var roles = await connection.QueryAsync<Role>(query);

                    if (roles.Count() <= 0 || roles == null)
                    {
                        return new List<Role>();
                    }

                    return roles.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all roles Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new List<Role>();
            }
        }

        public async Task<Role> GetById(long id)
        {
            try
            {
                _logger.LogInformation($"Get role by id");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetRoleByIdQuery(id);
                    var role = await connection.QueryAsync<Role>(query);

                    if (role == null)
                    {
                        return new Role();
                    }

                    return role.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get role by id Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new Role();
            }
        }

        public async Task<bool> Add(Role role)
        {
            try
            {
                _logger.LogInformation($"Add role: {JsonConvert.SerializeObject(role)}");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();

                    // input -> RoleName
                    parameters.Add("RoleName", role.Name,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    var result = await connection.ExecuteAsync("INSERT_ROLE", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add role Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> Update(Role role)
        {
            try
            {
                _logger.LogInformation($"Update role: {JsonConvert.SerializeObject(role)}");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();

                    // input -> RoleId
                    parameters.Add("RoleId", role.RoleId,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    // input -> RoleName
                    parameters.Add("RoleName", role.Name,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    var result = await connection.ExecuteAsync("UPDATE_ROLE", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update role Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return false;
            }
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
