using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeleSharp.TL;
using TeleSharp.TL.Messages;
using TestBack.BL.Services.Abstraction;
using TestBack.BL.Services.Concrete.Channels.Factory;
using TestBack.Models;
using TestBack.Models.ChannelSettings;
using TestBack.Models.Messages;
using TLSharp.Core;

namespace TestBack.BL.Services.Concrete.Channels
{
    internal class TelegramChannel : BaseChannel, IChannelService
    {
        private readonly TelegramSettings telegramSettings;

        public TelegramChannel(IOptionsMonitor<TelegramSettings> rulesAccessor, ILogger logger):base(logger)
        {
            telegramSettings = rulesAccessor.CurrentValue;
        }

        public async Task<Result> SendMessageAsync(MessageModel message)
        {
            Result result = new Result();

            try
            {
                using (var client = new TelegramClient(telegramSettings.ApiId, telegramSettings.ApiHash))
                {
                    await client.ConnectAsync();

                    var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
                    var chat = dialogs.Chats.Where(x => x.GetType() == typeof(TLChannel)).Cast<TLChannel>().FirstOrDefault(x => x.Title == telegramSettings.Channel);
                    await client.SendMessageAsync(new TLInputPeerChannel()
                    { ChannelId = chat.Id, AccessHash = chat.AccessHash.Value },
                        $"{message.Subject} {Environment.NewLine} {message.Body}");
                }
                result = new Result() { Success = true, Data = GetType().Name, ProjectId = message.ProjectId };
            }

            catch (Exception ex)
            {
                result = new Result() { Success = false, Errors = new List<string>() { ex.Message }, Data = GetType().Name, ProjectId = message.ProjectId };
            }

            await Log(result);
            return result;
        }
    }
}
