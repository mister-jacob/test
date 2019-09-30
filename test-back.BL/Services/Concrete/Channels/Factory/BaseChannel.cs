using System;
using System.Threading.Tasks;
using TestBack.BL.Services.Abstraction;
using TestBack.Models;

namespace TestBack.BL.Services.Concrete.Channels.Factory
{
    internal abstract class BaseChannel
    {
        private readonly ILogger _logger;

        public BaseChannel(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public virtual async Task Log(Result result)
        {
            await _logger.Log(result);
        }
    }
}
