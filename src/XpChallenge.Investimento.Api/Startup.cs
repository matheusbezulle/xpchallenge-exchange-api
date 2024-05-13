using XpChallenge.Investimento.Api.Configurations.Extensions;
using XpChallenge.Investimento.Api.Managers;
using XpChallenge.Investimento.Application.Ioc;
using XpChallenge.Investimento.Infra.External.Ioc;

namespace XpChallenge.Investimento.Api
{
    public class Startup(IConfiguration configuration)
    {
        private readonly StartupManager _startupManager = new();
        private readonly IConfiguration _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersApiBehavior();
            services.AddSwaggerConfiguration();
            services.AddApplication();
            services.AddMongo(_configuration);
            services.AddExternalConfiguration(_configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            _startupManager.Configure(app);
        }
    }
}
