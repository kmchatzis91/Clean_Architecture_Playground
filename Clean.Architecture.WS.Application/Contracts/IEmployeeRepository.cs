using Clean.Architecture.WS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Application.Contracts
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }
}
