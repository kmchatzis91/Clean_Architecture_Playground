using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Infrastructure.Context;
using Clean.Architecture.WS.Sql.Queries;
using Dapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Clean.Architecture.WS.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        #region Fields & Properties
        private readonly ILogger<CompanyRepository> _logger;
        private readonly DapperContext _dapperContext;
        #endregion

        #region Constructor
        public CompanyRepository(ILogger<CompanyRepository> logger, DapperContext dapperContext)
        {
            _logger = logger;
            _dapperContext = dapperContext;
        }
        #endregion

        #region Methods Common
        public async Task<List<Company>> Get()
        {
            try
            {
                _logger.LogInformation($"Get all companies");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetCompaniesQuery();
                    var companies = await connection.QueryAsync<Company>(query);

                    if (companies.Count() <= 0 || companies == null)
                    {
                        return new List<Company>();
                    }

                    return companies.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get all companies Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new List<Company>();
            }
        }

        public async Task<Company> GetById(long id)
        {
            try
            {
                _logger.LogInformation($"Get company by id");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var _sqlScripts = new SqlQueries();
                    var query = _sqlScripts.GetCompanyByIdQuery(id);
                    var company = await connection.QueryAsync<Company>(query);

                    if (company == null)
                    {
                        return new Company();
                    }

                    return company.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Get company by id Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return new Company();
            }
        }

        public async Task<bool> Add(Company company)
        {
            try
            {
                _logger.LogInformation($"Add company: {JsonConvert.SerializeObject(company)}");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();

                    // input -> CompanyName
                    parameters.Add("CompanyName", company.Name,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    var result = await connection.ExecuteAsync("INSERT_COMPANY", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add company Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<bool> Update(Company company)
        {
            try
            {
                _logger.LogInformation($"Update company: {JsonConvert.SerializeObject(company)}");

                using (var connection = _dapperContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();

                    // input -> CompanyId
                    parameters.Add("CompanyId", company.CompanyId,
                        dbType: DbType.Int64,
                        direction: ParameterDirection.Input);

                    // input -> CompanyName
                    parameters.Add("CompanyName", company.Name,
                        dbType: DbType.AnsiString,
                        direction: ParameterDirection.Input);

                    var result = await connection.ExecuteAsync("UPDATE_COMPANY", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Update company Error, Message: {ex.Message}, StackTrace: {ex.StackTrace}");
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
