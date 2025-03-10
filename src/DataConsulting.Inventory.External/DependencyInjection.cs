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
        public static IServiceCollection AddExternal(
        this IServiceCollection services
        )
        {
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
