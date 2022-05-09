using System.Collections.Generic;

namespace WellsFargo.Homework.Services
{
    public interface IExportService
    {
        public string Export(Dictionary<string, List<Order>> orders, string fileName);
    }
}