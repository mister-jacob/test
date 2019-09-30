using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TestBack.BL.Services.Abstraction;
using TestBack.BL.Services.Concrete.Channels.Factory;
using TestBack.Models;
using TestBack.Models.ChannelSettings;
using TestBack.Models.Messages;

namespace TestBack.BL.Services.Concrete.Channels
{
    internal class SmtpChannel : BaseChannel, IChannelService
    {
        private readonly SmtpSettings smtpSettings;

        public SmtpChannel(IOptionsMonitor<SmtpSettings> rulesAccessor, ILogger logger) :base(logger)
        {
            smtpSettings = rulesAccessor.CurrentValue;
        }

        public async Task<Result> SendMessageAsync(MessageModel message)
        {
            Result result = new Result();

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(smtpSettings.FromEmail);
            mailMessage.To.Add(smtpSettings.ToEmail);
            mailMessage.Body = message.Body;
            mailMessage.Subject = message.Subject;

            try
            {
                using (SmtpClient client = new SmtpClient(smtpSettings.Host, smtpSettings.Port))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpSettings.FromEmail, smtpSettings.Password);
                    await client.SendMailAsync(mailMessage);
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
