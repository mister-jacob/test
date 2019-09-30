using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestBack.BL.Extensions;
using TestBack.Extensions;
using TestBack.Models.ChannelSettings;
using TestBack.Models.Rules;

namespace TestBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            services.AddInternalServices();

            var rulesConfigBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("rules.json", optional: true);
            var rulesConfig = rulesConfigBuilder.Build();

            services.Configure<List<RuleModel>>(rulesConfig.GetSection("rules"));


            var settings = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: true);
             var smtpSettings = settings.Build();
             var telegramSettings = settings.Build();

            services.Configure<SmtpSettings>(smtpSettings.GetSection("smtpSettings"));
            services.Configure<TelegramSettings>(telegramSettings.GetSection("telegramSettings"));
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));


        }
    }
}
