using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PluralSightCoreProject_CityInfo.Models;

namespace PluralSightCoreProject_CityInfo.Services
{
    public class LocalMailService : IMailService
    {
        private readonly ILogger<LocalMailService> logger;
        private readonly IOptions<EmailConfigurationModel> _emailConfiguration;

        private string MailFrom { get; set; }
        private string MailTo { get; set; }

        public LocalMailService(ILogger<LocalMailService> logger, IOptions<EmailConfigurationModel> emailConfiguration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(ILogger<LocalMailService>));

            _emailConfiguration = emailConfiguration ?? throw new ArgumentNullException(nameof(EmailConfigurationModel));

            MailFrom = _emailConfiguration.Value.MailFromAddress;
            MailTo = _emailConfiguration.Value.MailToAddress;
        }

        public void Sent()
        {
            this.logger.LogInformation($"Sending email using: *** {nameof(LocalMailService)} ***, form {MailFrom}, to: {MailTo} address");
        }
    }
}