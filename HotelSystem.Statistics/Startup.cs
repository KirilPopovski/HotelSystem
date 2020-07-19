using HotelSystem.Common.Infrastructure;
using HotelSystem.Statistics.Data;
using HotelSystem.Statistics.Services.Feedback;
using HotelSystem.Statistics.Services.HotelViews;
using HotelSystem.Statistics.Services.Statistics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotelSystem.Statistics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddWebService<StatisticsDbContext>(this.Configuration);
            services.AddTransient<IStatisticsService, StatisticsService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IHotelViewService, HotelViewService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
