using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace XpChallenge.Investimento.Api.Configurations.Extensions
{
    public static class SwaggerConfigurationExtension
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "API de Transações",
                    Description = "Este projeto é uma API .NET que permite um usuário comprar e vender produtos financeiros, além de consultar sua carteira de investimentos e o extrato de todas as operações realizadas."
                });

                c.MapType<int>(() => new OpenApiSchema() { Type = "integer", Default = new OpenApiInteger(0) });
                c.MapType<DateTime>(() => new OpenApiSchema() { Type = "datetime", Default = new OpenApiString("01/01/0001") });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
