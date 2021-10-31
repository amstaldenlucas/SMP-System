using Microsoft.Extensions.DependencyInjection;
using SMPSystem.Areas.Web.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPSystem.Services
{
    internal static class ServicesConfiguration
    {
        internal static IServiceCollection ConfigureHandlerServices(this IServiceCollection services)
        {
            services.AddScoped<ProductHandler>();
            services.AddScoped<ProviderHandler>();
            services.AddScoped<GroupHandler>();
            services.AddScoped<SubgroupHandler>();

            return services;
        }


    }
}
