using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XpChallenge.Exchange.Infra.External.Apis;
using XpChallenge.Exchange.Infra.External.Clients;
using XpChallenge.Exchange.Infra.External.Clients.Interfaces;

namespace XpChallenge.Exchange.Infra.External.Ioc
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
