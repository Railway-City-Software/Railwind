using System.Security.Principal;
using Microsoft.Extensions.DependencyInjection;
using Railwind.Features.Chats;

namespace Railwind.Common;

public static class RegisterRailwindChatServices
{
    public static IServiceCollection AddChatRailwindServices<TRailChatHub, TRailChatService, TAccount, TChat>(this IServiceCollection services) where TRailChatHub : RailChatHub<TAccount, TChat> where TRailChatService : RailChatService<TAccount, TChat>
    {
        // Register JWT token service
        services.AddScoped<RailChatHub<TAccount, TChat>, TRailChatHub>();
        services.AddScoped<RailChatService<TAccount, TChat>, TRailChatService>();

        return services;
    }
}