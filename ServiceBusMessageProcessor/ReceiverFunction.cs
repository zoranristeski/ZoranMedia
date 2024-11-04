using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using ZoranMedia.Application.Services;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;

namespace ServiceBusMessageProcessor
{
    public class ReceiverFunction
    {      
        private readonly IClientService _clientService;
        private readonly IEmailService _emailService;
        private readonly ICampaignService _campaignService;

        public ReceiverFunction(IClientService clientService, IEmailService emailService,ICampaignService campaignService)
        {
            _clientService = clientService;
            _emailService = emailService;
            _campaignService = campaignService;
        }
        [FunctionName("ReceiverFunction")]
        public async Task Run([ServiceBusTrigger("emailnotification", Connection = "ServiceBusConnection")] MessagePayload message, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {message}");
            var clients = await _clientService.GetClientsByGenderAsync(message.Gender);

            //await _emailService.SendEmail("zoran_risteski89@hotmail.com", "Test Subject Title", "Test body");
            foreach (var client in clients)
            {
                var campaignTemplateClients = await _campaignService.GetAllCampaignsTemplateByClientIDAsync(client.ClientID);
                foreach (var campaignTemplateClient in campaignTemplateClients)
                {
                    await _emailService.SendEmail(campaignTemplateClient.EmailAddress, campaignTemplateClient.CampaignName, campaignTemplateClient.Content);
                }
            }
        }
    }
}
