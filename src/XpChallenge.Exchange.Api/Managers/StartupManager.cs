using XpChallenge.Exchange.Api.Configurations.Extensions;
using XpChallenge.Exchange.Api.Middlawares.ExceptionMiddlaware;

namespace XpChallenge.Exchange.Api.Managers
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
