using Clean.Architecture.WS.Application.Contracts;
using Clean.Architecture.WS.Infrastructure.Context;
using Clean.Architecture.WS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Architecture.WS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
        }
    }
}
