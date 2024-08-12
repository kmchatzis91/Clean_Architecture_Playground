using Clean.Architecture.WS.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields & Properties
        public IEmployeeRepository EmployeeRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        #endregion

        #region Constructor
        public UnitOfWork(
            IEmployeeRepository employeeRepository, 
            ICompanyRepository companyRepository, 
            IRoleRepository roleRepository)
        {
            EmployeeRepository = employeeRepository;
            CompanyRepository = companyRepository;
            RoleRepository = roleRepository;
        }
        #endregion
    }
}
