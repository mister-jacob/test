using System.Collections.Generic;
using System.Threading.Tasks;
using TestBack.Models;
using TestBack.Models.Messages;

namespace TestBack.BL.Services.Abstraction
{
    interface INotificationService
    {
        Task<IEnumerable<Result>> NotificateAsync(IEnumerable<MessageModel> messages, IEnumerable<IChannelService> channels);
    }
}
