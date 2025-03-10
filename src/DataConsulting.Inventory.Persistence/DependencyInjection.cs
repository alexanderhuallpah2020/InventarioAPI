using Dapper;
using DataConsulting.Inventory.Application.Abstractions.Common;
using DataConsulting.Inventory.Application.Abstractions.Data;
using DataConsulting.Inventory.Application.Abstractions.Email;
using DataConsulting.Inventory.Domain.Abstractions;
using DataConsulting.Inventory.Domain.Products;
using DataConsulting.Inventory.Domain.Users;
using DataConsulting.Inventory.Persistence.Clock;
using DataConsulting.Inventory.Persistence.Data;
using DataConsulting.Inventory.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            //services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("ConnectionString")
             ?? throw new ArgumentNullException(nameof(configuration));


            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            return services;
        }


    }
}
