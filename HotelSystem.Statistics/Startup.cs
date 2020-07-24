using HotelSystem.Common.Infrastructure;
using HotelSystem.Statistics.Data;
using HotelSystem.Statistics.Messages;
using HotelSystem.Statistics.Services.Feedback;
using HotelSystem.Statistics.Services.HotelViews;
using HotelSystem.Statistics.Services.Statistics;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            services.AddMassTransit(x =>
                {
                    x.AddConsumer<ReservationCreatedConsumer>();
                    x.AddConsumer<HotelVisitedConsumer>();
                    x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host("rabbitmq", host =>
                        {
                            host.Username("rabbitmq");
                            host.Password("rabbitmq");
                        });

                        cfg.ReceiveEndpoint(nameof(ReservationCreatedConsumer), endpoint =>
                        {
                            endpoint.ConfigureConsumer<ReservationCreatedConsumer>(context);
                        });
                        cfg.ReceiveEndpoint(nameof(HotelVisitedConsumer), endpoint =>
                        {
                            endpoint.ConfigureConsumer<HotelVisitedConsumer>(context);
                        });
                    }));
                })
                .AddMassTransitHostedService();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
