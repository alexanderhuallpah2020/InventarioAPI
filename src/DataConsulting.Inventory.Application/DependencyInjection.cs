using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConsulting.Inventory.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                //configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
                //configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));

            });

            //services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            //services.AddTransient<PrecioService>();

            return services;
        }
    }
}
