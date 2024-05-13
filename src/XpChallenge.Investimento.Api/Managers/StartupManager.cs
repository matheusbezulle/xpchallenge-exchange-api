using XpChallenge.Investimento.Api.Configurations.Extensions;
using XpChallenge.Investimento.Api.Middlawares.ExceptionMiddlaware;

namespace XpChallenge.Investimento.Api.Managers
{
    public class StartupManager()
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwaggerConfiguration();
            app.UseRouting();
            app.UseMiddleware(typeof(ExceptionMiddlaware));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
