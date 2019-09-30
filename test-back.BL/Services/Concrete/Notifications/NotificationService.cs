using System.Collections.Async;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestBack.BL.Services.Abstraction;
using TestBack.Models;
using TestBack.Models.Messages;

namespace TestBack.BL.Services.Concrete.Notifications
{
    internal class NotificationService : INotificationService
    {
        public async Task<IEnumerable<Result>> NotificateAsync(IEnumerable<MessageModel> messages, IEnumerable<IChannelService> channels)
        {
            ConcurrentBag<Result> results = new ConcurrentBag<Result>();

            await channels.ParallelForEachAsync(async i =>
            {
                foreach (var message in messages)
                    results.Add(await i.SendMessageAsync(message));
            },
            maxDegreeOfParalellism: 10);

            return results;
        }
    }
}
