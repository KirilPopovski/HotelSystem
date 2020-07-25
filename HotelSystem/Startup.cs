using Hangfire;
using HotelSystem.Common;
using HotelSystem.Common.Infrastructure;
using HotelSystem.Common.Messages;
using HotelSystem.Data;
using HotelSystem.Services.Guests;
using HotelSystem.Services.Home;
using HotelSystem.Services.Reservations;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelSystem
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
                .AddWebService<GuestsDbContext>(this.Configuration)
                .AddTransient<IGuestsService, GuestsService>()
                .AddTransient<IReservationService, ReservationsService>()
                .AddTransient<IHomeService, HomeService>()
                .AddMassTransit(x =>
                {
                    x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(cfg =>
                    {
                        cfg.Host("rabbitmq", host =>
                        {
                            host.Username("rabbitmq");
                            host.Password("rabbitmq");
                        });

                        cfg.UseHealthCheck(context);
                    }));
                })
                .AddMassTransitHostedService();

            services
                .AddHangfire(config => config
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    .UseSqlServerStorage(this.Configuration.GetDefaultConnectionString()));

            services.AddHangfireServer();

            services.AddHostedService<MessagesHostedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebService(env)
                .Initialize();
        }
    }
}
