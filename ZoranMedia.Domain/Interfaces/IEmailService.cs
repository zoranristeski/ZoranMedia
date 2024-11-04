using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Domain.Interfaces
{
    public interface IEmailService 
    {
        Task SendEmail(string to, string subject, string body);
        Task SendBulkEmails(IEnumerable<EmailMessageDto> emailMessages);
    }
}
