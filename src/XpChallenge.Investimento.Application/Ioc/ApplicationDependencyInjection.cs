using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using XpChallenge.Investimento.Application.Notifications;
using XpChallenge.Investimento.Application.Services;
using XpChallenge.Investimento.Application.Services.Interfaces;

namespace XpChallenge.Investimento.Application.Ioc
{
    public static class ApplicationDependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMapper();
            services.AddMediatR(mfg => mfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<ICarteiraService, CarteiraService>();
            services.AddScoped<IOperacaoService, OperacaoService>();
            services.AddScoped<IProdutoFinanceiroService, ProdutoFinanceiroService>();
        }
    }
}
