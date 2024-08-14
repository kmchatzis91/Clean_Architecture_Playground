using Clean.Architecture.WS.Domain.Entities;
using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Mappings
{
    public class RoleMap : EntityMap<Role>
    {
        public RoleMap()
        {
            Map(x => x.RoleId).ToColumn("ROLE_ID");
            Map(x => x.Name).ToColumn("ROLE_NAME");
        }
    }
}
