using Hangfire;
using HotelSystem.Common.Data.Models;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSystem.Common.Messages
{
    public class MessagesHostedService : IHostedService
    {
        private readonly IRecurringJobManager recurringJob;
        private readonly DbContext db;
        private readonly IBus publisher;

        public MessagesHostedService(IRecurringJobManager recurringJob, DbContext db, IBus publisher)
        {
            this.recurringJob = recurringJob;
            this.db = db;
            this.publisher = publisher;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.recurringJob.AddOrUpdate(
                nameof(MessagesHostedService),
                () => this.ProcessPendingMessages(),
                "*/10 * * * * *");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void ProcessPendingMessages()
        {
            var messages = this.db
                .Set<Message>()
                .Where(m => !m.Published)
                .ToList();
            foreach (var message in messages)
            {
                this.publisher.Publish(message.Data, message.Type);

                message.MarkAsPublished();

                this.db.SaveChanges();
            }
        }
    }
}
