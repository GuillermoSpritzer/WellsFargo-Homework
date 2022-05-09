using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;
using WellsFargo.Homework.Services.Orders;

namespace WellsFargo.Homework.Services.Factory
{
    public class OrderFactoryAAA :IOrderFactory
    {
        public string Id { get => "AAA"; }

        public Order CreateOrder(Transaction t, Portfolio p, Security s)
        {
            return new OrderAAA() { ISIN = s.ISIN, Nominal = t.Nominal, PortfolioCode = p.PortfolioCode, TransactionType = t.TransactionType };
        }
    }
}
