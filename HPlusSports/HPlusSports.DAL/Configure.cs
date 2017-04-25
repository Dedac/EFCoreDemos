using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HPlusSports.Models;

namespace HPlusSports.DAL
{
    public static class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            //Context lifetime defaults to "scoped"
            services
                 .AddDbContext<HPlusSportsContext>(options => options.UseSqlServer(connectionString));

            services
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IRepository<Customer>, AtomicRepository<Customer>>()
                .AddScoped<IRepository<Product>, AtomicRepository<Product>>()
                .AddScoped<ISalesPersonRepository, SalesPersonRepository>();
        }
    }
}
