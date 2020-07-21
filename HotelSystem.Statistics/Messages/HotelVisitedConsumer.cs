using HotelSystem.Common.Messages.Hotels;
using HotelSystem.Statistics.Services.HotelViews;
using MassTransit;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Messages
{
    public class HotelVisitedConsumer : IConsumer<HotelVisitedMessage>
    {
        private readonly IHotelViewService service;

        public HotelVisitedConsumer(IHotelViewService service)
        {
            this.service = service;
        }

        public async Task Consume(ConsumeContext<HotelVisitedMessage> context)
        {
            var message = context.Message;
            await this.service.AddHotelView(message.HotelId);
        }
    }
}
