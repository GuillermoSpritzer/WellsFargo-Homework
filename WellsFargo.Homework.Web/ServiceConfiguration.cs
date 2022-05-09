using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WellsFargo.Homework.Services;

namespace WellsFargo.Homework.Web
{
    public class ServiceConfiguration : IServiceConfiguration
    {
        public string FolderSecurities { get; set; }
        public string FolderPortfolios { get; set; }
        public string FolderOrders { get; set; }


        public ServiceConfiguration(IConfiguration configuration)
        {
            FolderSecurities = configuration.GetValue<string>("Folders:In:Securities");
            FolderPortfolios = configuration.GetValue<string>("Folders:In:Portfolio");
            FolderOrders = configuration.GetValue<string>("Folders:Out:Orders");

        }
    }
}
