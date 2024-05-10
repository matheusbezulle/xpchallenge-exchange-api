using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using XpChallenge.Exchange.Application.Notifications;
using XpChallenge.Exchange.Application.Services;
using XpChallenge.Exchange.Application.Services.Interfaces;

namespace XpChallenge.Exchange.Application.Ioc
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddMediatR(mfg => mfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<IOperacaoService, OperacaoService>();
        }
    }
}
