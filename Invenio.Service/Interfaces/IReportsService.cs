using Invenio.Service.Models;
using System.Collections.Generic;

namespace Invenio.Service.Interfaces
{
    public interface IReportsService
    {
        void Create(string ReportText, string orderId);

        ReportModel ReportById(string id);

        bool CheckForOrderId(string orderId);
    }
}
