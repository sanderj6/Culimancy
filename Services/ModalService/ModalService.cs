using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Culimancy.Services.ModalService
{
    public static class ModalService
    {
        public static IServiceCollection AddModals(this IServiceCollection services)
        {
            return services.AddScoped<ModalHandler>();
        }
    }
}
