using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace HotelSystem.Watchdog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseRouting()
                .UseEndpoints(endpoints => endpoints
                    .MapHealthChecksUI());
        }
    }
}
