using System.Threading.Tasks;
using TestBack.Models;
using TestBack.Models.Messages;

namespace TestBack.BL.Services.Abstraction
{
    interface IChannelService
    {
        Task<Result> SendMessageAsync(MessageModel message);
    }
}
