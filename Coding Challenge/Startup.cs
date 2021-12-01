using Coding_Challenge;
using Coding_Challenge.Business;
using Coding_Challenge.Common.Logging;
using Coding_Challenge.Repository;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Coding_Challenge
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions();

            this.ConfigureServices(builder.Services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IVisitorsService, VisitorsService>();
            services.AddScoped<ILogg, Logg>();
            services.AddSingleton<IVisitorsRepository, VisitorsRepository>();
        }
    }
}