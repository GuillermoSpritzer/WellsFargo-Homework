using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo.Homework.Services
{
    public interface IServiceConfiguration
    {

        public string FolderSecurities { get; set; }
        public string FolderPortfolios { get; set; }
        public string FolderOrders { get; set; }

    }    
}
