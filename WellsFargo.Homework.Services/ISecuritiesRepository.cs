using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;

namespace WellsFargo.Homework.Services
{
    public interface ISecuritiesRepository
    {
        public Security GetSecurities(int id);
    }
        
        
}
