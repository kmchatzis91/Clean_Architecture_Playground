using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Application.Contracts
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IRoleRepository RoleRepository { get; }
    }
}
