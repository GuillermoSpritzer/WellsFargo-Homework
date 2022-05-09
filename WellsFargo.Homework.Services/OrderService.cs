using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;
using WellsFargo.Homework.Services.Factory;

namespace WellsFargo.Homework.Services
{
    public class OrderService : IOrderService
    {

        private IPortfolioRepository _portfolioRepository { get; set; }
        private ISecuritiesRepository _securitiesRepository { get; set; }
        private Dictionary<string, IOrderFactory> _orderFactory {get;set;}


        public OrderService(IPortfolioRepository portfolioRepository, ISecuritiesRepository securitiesRepository)
        {
            _portfolioRepository = portfolioRepository;
            _securitiesRepository = securitiesRepository;
            _orderFactory = new Dictionary<string, IOrderFactory>();
            _orderFactory.TryAdd("AAA", new OrderFactoryAAA());
            _orderFactory.TryAdd("BBB", new OrderFactoryBBB());
            _orderFactory.TryAdd("CCC", new OrderFactoryCCC());
        }

        public Dictionary<string,List<Order>> CreateOrders(List<Transaction> transactions)
        {
            var listOrders =new Dictionary<string, List<Order>>();
            foreach(var factory in _orderFactory)
            {                
                var list = new List<Order>();
               foreach (var t in  transactions.Where(t => t.OMS == factory.Key).ToList())
               {
                    var portfolio = _portfolioRepository.GetPortfolio(t.PortfolioId);
                    var security = _securitiesRepository.GetSecurities(t.SecurityId);
                    if (portfolio == null || security == null)
                        continue;
                    list.Add(factory.Value.CreateOrder(t, portfolio, security));
               }
               if(list.Count > 0)
                    listOrders.TryAdd(factory.Key,list);
            }
            return listOrders;
        }      

    }
}
