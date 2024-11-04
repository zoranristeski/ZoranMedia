using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;
using Azure.Communication.Email;

namespace ZoranMedia.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
       
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task SendBulkEmails(IEnumerable<EmailMessageDto> emailMessages)
        {
            foreach (var emailMessage in emailMessages)
            {
                await SendEmail(emailMessage.ToRecipient, emailMessage.Subject, emailMessage.Body);
            }
        }
        public async Task SendEmail(string to, string subject, string body)
        {
            //var connString = _configuration["AzureEmailConnString:DefaultConnection"];
            var connString = "endpoint=https://zoranmediacommunicationservice.europe.communication.azure.com/;accesskey=BZJ7uHl3rUwhriCbvULKHMHCinpDAFxUiVktm0GWGxTBeX9uw37JJQQJ99AKACULyCpchpZzAAAAAZCS3FpP";
            EmailClient emailClient = new EmailClient(connString);
            var subjectText = subject;
            var bodyText = body;
            var sender = "DoNotReply@3ef34c94-7ee1-4a5d-8fe0-a719d3882b0a.azurecomm.net";
            var recipient = "zoran_risteski89@hotmail.com";
            try
            {
                EmailSendOperation emailSendOperation = await emailClient.SendAsync(Azure.WaitUntil.Completed, sender, recipient, subjectText, bodyText);
                EmailSendResult status = emailSendOperation.Value;             
            }
            catch (Exception e)
            {
                throw;
            }
        }
        //public async Task SendEmail(string to, string subject, string body)
        //{

        //    //string email = _configuration["SendGrid:SenderEmail"];
        //    //string name = _configuration["SendGrid:SenderName"];
        //    //string apiKey = _configuration["SendGrid:SenderApiKey"];


        //    //var client = new SendGridClient(apiKey);

        //    //var from = new EmailAddress(email,name);
        //    //var to = new EmailAddress("zoranristeski89@gmail.com");
        //    //var msg = MailHelper.CreateSingleEmail(from, to, "Subject test", "Test Email Body","");

        //    //var response = await client.SendEmailAsync(msg);

        //    var message = new MimeMessage();
        //    message.From.Add(new MailboxAddress("ZoranMedia", "zoranmedia.dev@gmail.com"));
        //    message.To.Add(new MailboxAddress(to, to));
        //    message.Subject = subject;
        //    message.Body = new TextPart("plain")
        //    {
        //        Text = body
        //    };
        //    using (var clientmsg = new SmtpClient())
        //    {
        //        clientmsg.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
        //        clientmsg.Authenticate("zoranmedia.dev@gmail.com", "Zoran123*");
        //        clientmsg.Send(message);
        //        clientmsg.Disconnect(true);
        //    }
        //}
    }
}
