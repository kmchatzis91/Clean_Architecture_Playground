using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Sql.Queries
{
    public class SqlQueries
    {
        #region Methods Employee
        public string GetEmployeesQuery()
        {
            return "select * from employee_v";
        }
        #endregion
    }
}
