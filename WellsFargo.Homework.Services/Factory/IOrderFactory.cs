using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;

namespace WellsFargo.Homework.Services.Factory
{
    public interface IOrderFactory
    {
        public string Id { get; }
        public Order CreateOrder(Transaction t, Portfolio p , Security s);
    }
}
