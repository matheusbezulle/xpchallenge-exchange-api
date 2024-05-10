using Microsoft.Extensions.DependencyInjection;
using XpChallenge.Exchange.Infra.Mongo.Repositories;
using XpChallenge.Exchange.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Exchange.Infra.Mongo.Ioc
{
    public static class MongoDependencyInjection
    {
        public static void AddInfraMongo(this IServiceCollection services)
        {
            services.AddScoped<ICarteiraRepository, CarteiraRepository>();
            services.AddScoped<IOperacaoRepository, OperacaoRepository>();
        }
    }
}
