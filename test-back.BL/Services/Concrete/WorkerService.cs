using TestBack.BL.Services.Abstraction;
using System.Collections.Generic;
using TestBack.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using TestBack.Models.Messages;

namespace TestBack.BL.Services.Concrete
{
    internal class WorkerService : IWorkerService
    {
        private readonly IRuleService _rule;
        private readonly INotificationService _notificationService;
        private readonly IChannelFactory _channelFactory;

        public WorkerService(IRuleService rule, INotificationService notificationService, IChannelFactory channelFactory)
        {
            _rule = rule ?? throw new ArgumentNullException(nameof(rule));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _channelFactory = channelFactory ?? throw new ArgumentNullException(nameof(channelFactory));
        }

        public async Task<IEnumerable<Result>> RunProcess(IEnumerable<DataModel> inputData)
        {
            var validData = _rule.GetValidRules(inputData);

            if (validData.Any())
            {
                var effects = _rule.GetEffects();
                var channels = _channelFactory.GetChannels(effects.Select(x => x.Type).ToArray());
                var results = await _notificationService.NotificateAsync(validData.Select(x => new MessageModel($"Project name: {x.Name}",
                                                                                                                $"Project name: {x.Name} Project description: {x.Description}",
                                                                                                                x.Id)),
                                                                                                                channels);
                return results;
            }

            return new List<Result>() { new Result() { Success = true, Data = "all of data are not valid"} };
        }
    }
}
