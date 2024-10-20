﻿using Microsoft.Extensions.DependencyInjection;

namespace Railwind.Common;

public static class RegisterRailwindServices
{

        public static IServiceCollection AddRailwindServices(this IServiceCollection services)
        {
            // Register JWT token service
            services.AddScoped<EventsJsInterop>();
        
            return services;
        }
    
}