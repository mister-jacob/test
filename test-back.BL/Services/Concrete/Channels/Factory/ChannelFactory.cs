using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using TestBack.BL.Common;
using TestBack.BL.Services.Abstraction;
using TestBack.Models.ChannelSettings;

namespace TestBack.BL.Services.Concrete.Channels.Factory
{
    internal class ChannelFactory : IChannelFactory
    {
        private readonly ILogger _logger; 
        private static Dictionary<TypesChannels, IChannelService> channels;

        public ChannelFactory(IOptionsMonitor<SmtpSettings> smtpSettings, IOptionsMonitor<TelegramSettings> telegramSettings, ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            channels = new Dictionary<TypesChannels, IChannelService>()
            {
                {TypesChannels.smtp, new SmtpChannel(smtpSettings, _logger)},
                {TypesChannels.telegram, new TelegramChannel(telegramSettings, _logger) }
            };
        }

        public IEnumerable<IChannelService> GetChannels(params string [] typesChannels)
        {
            foreach (var item in typesChannels)
                yield return channels[(TypesChannels)Enum.Parse(typeof(TypesChannels), item)];
        }
    }
}
