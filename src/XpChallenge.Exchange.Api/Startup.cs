using XpChallenge.Exchange.Api.Configurations.Extensions;
using XpChallenge.Exchange.Api.Managers;

namespace XpChallenge.Exchange.Api
{
    public class Startup(IConfiguration configuration)
    {
        private readonly StartupManager _startupManager = new();
        private readonly IConfiguration _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersApiBehavior();
            services.AddSwaggerConfiguration();
            //services.AddApplication();
            //services.AddMongo(_configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            _startupManager.Configure(app);
        }
    }
}
