using System;
using Microsoft.Extensions.Logging;

namespace PluralSightCoreProject_CityInfo.Services
{
    public class LocalMailService : IMailService
    {
        private readonly ILogger<LocalMailService> logger;

        public LocalMailService(ILogger<LocalMailService> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILogger<LocalMailService>));
        }

        public void Sent()
        {
            var a = Startup.Configuration["mailSettings:mailToAddress"];
            this.logger.LogInformation($"Sending email from: *** {nameof(LocalMailService)} ***");
        }
    }
}