using HotelSystem.Common.Messages.Guests;
using HotelSystem.Statistics.Services.Statistics;
using MassTransit;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Messages
{
    public class ReservationCreatedConsumer : IConsumer<ReservationCreatedMessage>
    {
        private readonly IStatisticsService statistics;

        public ReservationCreatedConsumer(IStatisticsService statistics)
        {
            this.statistics = statistics;
        }
        public async Task Consume(ConsumeContext<ReservationCreatedMessage> context)
        {
            var message = context.Message;
            await this.statistics.AddReservation();
        }
    }
}
