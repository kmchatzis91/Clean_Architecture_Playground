using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Core.Entities;
using Clean.Architecture.WS.Infrastructure.Context;
using Microsoft.Extensions.Logging;

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

        #region Methods
        public Task<List<Company>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
