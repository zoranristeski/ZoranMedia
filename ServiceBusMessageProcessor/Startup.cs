using Microsoft.Extensions.DependencyInjection;
using AzureFunctions.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using ZoranMedia.Domain.Interfaces;
using ZoranMedia.Application.Services;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Infrastructure;
using ZoranMedia.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using ZoranMedia.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using System.IO;

[assembly: FunctionsStartup(typeof(ServiceBusMessageProcessor.Startup))]

namespace ServiceBusMessageProcessor
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            
            builder.Services.AddDbContext<ZoranMediaDataContext>(options =>
                                    options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection")));
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
           
        }
    }
}
