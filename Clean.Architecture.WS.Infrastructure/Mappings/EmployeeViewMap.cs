using Clean.Architecture.WS.Domain.Entities;
using Clean.Architecture.WS.Domain.Views;
using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Mappings
{
    public class EmployeeViewMap : EntityMap<EmployeeView>
    {
        public EmployeeViewMap()
        {
            Map(x => x.EmployeeId).ToColumn("EMPLOYEE_ID");
            Map(x => x.FirstName).ToColumn("FIRST_NAME");
            Map(x => x.LastName).ToColumn("LAST_NAME");
            Map(x => x.Email).ToColumn("EMAIL");
            Map(x => x.PhoneNumber).ToColumn("PHONE_NUMBER");
            Map(x => x.RoleId).ToColumn("ROLE_ID");
            Map(x => x.RoleName).ToColumn("ROLE_NAME");
            Map(x => x.CompanyId).ToColumn("COMPANY_ID");
            Map(x => x.CompanyName).ToColumn("COMPANY_NAME");
        }
    }
}
