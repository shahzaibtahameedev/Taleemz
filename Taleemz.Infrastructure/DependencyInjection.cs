using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taleemz.Infrastructure.Data;

namespace Taleemz.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=DESKTOP-T2DBUFO\\SQLEXPRESS;Initial Catalog=taleemz.db;Integrated Security=True;Trust Server Certificate=True");
            });

            return services;
        }
    }
}
