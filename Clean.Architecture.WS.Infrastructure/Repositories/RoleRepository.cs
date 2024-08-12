using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Infrastructure.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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

        #region Methods
        public Task<List<Role>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> UpdateById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
