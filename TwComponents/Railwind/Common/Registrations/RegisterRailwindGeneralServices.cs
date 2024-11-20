using Microsoft.Extensions.DependencyInjection;
using Railwind.Features.Chats;
using Railwind.Features.Toasters;

namespace Railwind.Common;

public static class RegisterRailwindGeneralServices
{
    public static IServiceCollection AddGeneralRailwindServices(this IServiceCollection services)
    {
        // Register JWT token service
        services.AddScoped<EventsJsInterop>();
        services.AddSingleton<ToasterService>();
        services.AddScoped<GeneralJsInterop>();

        return services;
    }
}