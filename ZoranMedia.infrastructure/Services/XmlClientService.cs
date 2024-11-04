using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZoranMedia.Application.Services;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;

namespace ZoranMedia.Infrastructure.Services
{
    public class XmlClientService : IXmlClientService
    {
        private readonly IClientService _clientService;
        private readonly ITemplateService _templateService;
        private readonly ICampaignService _campaignService;

        public XmlClientService(IClientService clientService, ITemplateService templateService, ICampaignService campaignService)
        {
            _clientService = clientService;
            _templateService = templateService;
            _campaignService = campaignService;
        }

        public async Task ImportClientsAndTemplatesAsync(string xmlContent)
        {
            var xDocument = XDocument.Parse(xmlContent);

            foreach (var clientElement in xDocument.Descendants("Client"))
            {
                int clientId = int.Parse(clientElement.Attribute("ID")?.Value ?? "0");

               
                var client = new Client
                {
                    ClientID = clientId,
                    Name = clientElement.Element("Name")?.Value,
                   // EmailAddress = clientElement.Element("Email")?.Value
                };

       
                var templateElement = clientElement.Element("Template");
                if (templateElement != null)
                {
                    int templateId = int.Parse(templateElement.Attribute("Id")?.Value ?? "0");
                    string templateName = templateElement.Element("Name")?.Value;
                    string marketingData = templateElement.Element("MarketingData")?.Value;

                    
                    var template = await _templateService.GetOrCreateTemplateAsync(templateId, templateName, marketingData);

          
                    var campaign = new Campaign
                    {
                        Name = $"Campaign for Client {clientId}",
                        Template = template
                    };

                    campaign.Clients.Add(client);
                    client.Campaigns.Add(campaign);

              
                    await _campaignService.CreateCampaignAsync(campaign);
                    await _clientService.CreateClientAsync(client);
                }
            }
        }
    }
}
