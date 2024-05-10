using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using XpChallenge.Exchange.Infra.External.Configurations;

namespace XpChallenge.Exchange.Infra.External.Ioc
{
    public static class RefitConfigurationExtension
    {
        public static void AddRefitExternalConfiguration<T>(this IServiceCollection services, IConfiguration configuration, string apiName) where T : class
        {
            var externalConfigurations = configuration.GetSection("ExternalConfiguration").Get<List<ExternalConfiguration>>();
            var externalConfiguration = externalConfigurations?.First(x => x.Name == apiName);

            if (externalConfiguration != null)
            {
                var builder = services.AddRefitClient<T>();
                builder.ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(externalConfiguration.BaseAddress);
                });
            }
        }
    }
}
