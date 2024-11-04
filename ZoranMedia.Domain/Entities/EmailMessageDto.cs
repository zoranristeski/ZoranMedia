using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoranMedia.Domain.Entities
{
    public class EmailMessageDto
    {
        public string ToRecipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailMessageDto(string toRecipient, string subject, string body)
        {
            ToRecipient = toRecipient;
            Subject = subject;
            Body = body;
        }
    }
          
}
