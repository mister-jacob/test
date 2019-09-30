using System.Collections.Generic;

namespace TestBack.BL.Services.Abstraction
{
    interface IChannelFactory
    {
        IEnumerable<IChannelService> GetChannels(params string [] typesChannels);
    }
}
