using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;
using WellsFargo.Homework.Services.Orders;

namespace WellsFargo.Homework.Services.Factory
{
    public class OrderFactoryBBB : IOrderFactory
    {
        public string Id { get => "BBB"; }


        public Order CreateOrder(Transaction t, Portfolio p, Security s)
        {
            return new OrderBBB() { Cusip = s.Cusip, Nominal = t.Nominal, PortfolioCode = p.PortfolioCode, TransactionType = t.TransactionType };
        }
    }
}
