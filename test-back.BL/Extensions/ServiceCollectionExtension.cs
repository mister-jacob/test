using Microsoft.Extensions.DependencyInjection;
using TestBack.BL.Services.Abstraction;
using TestBack.BL.Services.Concrete;
using TestBack.BL.Services.Concrete.Channels;
using TestBack.BL.Services.Concrete.Channels.Factory;
using TestBack.BL.Services.Concrete.Loggers;
using TestBack.BL.Services.Concrete.Notifications;
using TestBack.BL.Services.Concrete.Rules;
using TestBack.Models.Rules;

namespace TestBack.BL.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IConditionService<ConditionModel>, ConditionService>();
            services.AddScoped<IRuleService, RuleJson>();
            services.AddScoped<IChannelService, SmtpChannel>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IChannelFactory, ChannelFactory>();
            services.AddScoped<ILogger, FileLogger>();
            return services;
        }
    }
}
