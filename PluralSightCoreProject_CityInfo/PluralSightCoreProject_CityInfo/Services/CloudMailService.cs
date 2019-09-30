using System;
using Microsoft.Extensions.Logging;

namespace PluralSightCoreProject_CityInfo.Services
{
    public class CloudMailService : IMailService
    {
        private readonly ILogger<CloudMailService> _logger;

        public CloudMailService(ILogger<CloudMailService> logger)
        {
            _logger = logger ?? throw new NullReferenceException(nameof(ILogger<CloudMailService>));
        }

        public void Sent()
        {
            _logger.LogInformation($"Sending email from: *** {nameof(CloudMailService)} ***");
        }
    }
}