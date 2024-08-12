using Clean.Architecture.WS.Domain.Entities;
using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Mappings
{
    public class CompanyMap : EntityMap<Company>
    {
        public CompanyMap()
        {
            Map(x => x.CompanyId).ToColumn("COMPANY_ID");
            Map(x => x.Name).ToColumn("COMPANY_NAME");
        }
    }
}
