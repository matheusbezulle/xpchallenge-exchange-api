using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XpChallenge.Investimento.Infra.External.Apis;
using XpChallenge.Investimento.Infra.External.Clients;
using XpChallenge.Investimento.Infra.External.Clients.Interfaces;

namespace XpChallenge.Investimento.Infra.External.Ioc
{
    public static class ExternalDependencyInjection
    {
        public static void AddExternalConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IAlphaVantageClient, AlphaVantageClient>();
            services.AddRefitExternalConfiguration<IAlphaVantageApi>(configuration, "AlphaVantage");
        }
    }
}
