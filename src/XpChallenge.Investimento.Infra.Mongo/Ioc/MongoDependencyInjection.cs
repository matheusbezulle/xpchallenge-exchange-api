using Microsoft.Extensions.DependencyInjection;
using XpChallenge.Investimento.Infra.Mongo.Repositories;
using XpChallenge.Investimento.Infra.Mongo.Repositories.Interfaces;

namespace XpChallenge.Investimento.Infra.Mongo.Ioc
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
