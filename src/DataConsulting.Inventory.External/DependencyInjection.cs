using DataConsulting.Inventory.Application.Abstractions.Email;
using DataConsulting.Inventory.External.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.External
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
        {
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
