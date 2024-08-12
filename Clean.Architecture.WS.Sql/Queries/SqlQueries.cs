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
            return "select * from employee";
        }

        public string GetEmployeesViewQuery()
        {
            return "select * from employee_v";
        }

        public string GetEmployeeByIdQuery(long id)
        {
            return $"select * from employee where EMPLOYEE_ID = {id}";
        }

        public string GetEmployeeByIdViewQuery(long id)
        {
            return $"select * from employee_v where EMPLOYEE_ID = {id}";
        }
        #endregion

        #region Methods Company
        public string GetCompaniesQuery()
        {
            return "select * from company";
        }

        public string GetCompaniesViewQuery()
        {
            return "select * from company_v";
        }

        public string GetCompanyByIdQuery(long id)
        {
            return $"select * from company where COMPANY_ID = {id}";
        }

        public string GetCompanyByIdViewQuery(long id)
        {
            return $"select * from company_v where COMPANY_ID = {id}";
        }
        #endregion

        #region Methods Role
        public string GetRolesQuery()
        {
            return "select * from role";
        }

        public string GetRolesViewQuery()
        {
            return "select * from role_v";
        }

        public string GetRoleByIdQuery(long id)
        {
            return $"select * from role where ROLE_ID = {id}";
        }

        public string GetRoleByIdViewQuery(long id)
        {
            return $"select * from role_v where ROLE_ID = {id}";
        }
        #endregion
    }
}
