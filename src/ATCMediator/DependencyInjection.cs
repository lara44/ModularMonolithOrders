

using System.Reflection;
using ATCMediator.Mediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ATCMediator
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddATCMediator(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<IAtcMediator, Mediator.AtcMediator>();

            foreach (var assembly in assemblies)
            {
                // Registrar IRequestHandler<T>
                var atcRequestHandlerType = typeof(IAtcRequestHandler<,>);
                var atcRequestHandlers = assembly.GetTypes()
                    .Where(t => t.GetInterfaces().Any(i =>
                        i.IsGenericType && i.GetGenericTypeDefinition() == atcRequestHandlerType));

                foreach (var handler in atcRequestHandlers)
                {
                    var @interface = handler.GetInterfaces()
                        .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == atcRequestHandlerType);
                    services.AddScoped(@interface, handler);
                }
            }

            return services;
        }
    }
}