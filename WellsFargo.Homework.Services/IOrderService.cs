using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo.Homework.Services
{
    public interface IOrderService
    {
        public Dictionary<string, List<Order>> CreateOrders(List<Transaction> transactions);

    }
}
