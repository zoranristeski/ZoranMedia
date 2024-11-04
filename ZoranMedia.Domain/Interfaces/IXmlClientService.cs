using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZoranMedia.Domain.Entities;

namespace ZoranMedia.Domain.Interfaces
{
    public interface IXmlClientService
    {
        Task ImportClientsAndTemplatesAsync(string xmlFilePath);
    }
}
