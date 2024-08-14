using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Application.Contracts
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<List<EmployeeView>> GetView();
        Task<EmployeeView> GetViewById(long id);
    }
}
