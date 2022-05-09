using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WellsFargo.Homework.Services.Factory;
using WellsFargo.Homework.Services.Orders;

namespace WellsFargo.Homework.Services.Tests
{
    [TestFixture]
    public class TestOrderServices
    {

        public PortfolioRepository _portfolioRepository { get; set; }
        public SecuritiesRepository _securitiesRepository { get; set; }
        public OrderService _orderService { get; set; }
        public Dictionary<string, IOrderFactory> _orderFactory { get; set; }

        public List<Transaction> transactions { get; set; }

        [SetUp]
        public void Setup()
        {
            _portfolioRepository = new PortfolioRepository(new ServiceConfigurationTest());
            _securitiesRepository = new SecuritiesRepository(new ServiceConfigurationTest());
            _orderService = new OrderService(_portfolioRepository, _securitiesRepository);
            _orderFactory = new Dictionary<string, IOrderFactory>();
        }

        [TestCase(56, 2, 1, "UUU", "SELL", 0)]
        [TestCase(56, 2, 1, "AAA", "SELL", 1)]
        [TestCase(56, 1, 2, "BBB", "SELL", 1)]
        public void Test_OrderFactoryNotExists_CreateOrder(decimal nominal, int portfolioId, int securityId, string OMS, string transactionType, int expectedResult)
        {
            //Arrange
            var list = new List<Transaction>();
            list.Add(new Transaction() { Nominal = nominal, PortfolioId = portfolioId, SecurityId = securityId, OMS = OMS, TransactionType = transactionType });
            //Act
            var orders = _orderService.CreateOrders(list);
            //Assert
            Assert.AreEqual(orders.Count, expectedResult);
        }


        [TestCase(56, 2, 4, "AAA", "SELL", 0)]
        [TestCase(56, 2, 9, "BBB", "BUY", 0)]
        [TestCase(56, 2, 1, "AAA", "SELL", 1)]
        public void Test_OrderPortfolioNotExists_CreateOrder(decimal nominal, int portfolioId, int securityId, string OMS, string transactionType, int expectedResult)
        {
            //Arrange
            var list = new List<Transaction>();
            list.Add(new Transaction() { Nominal = nominal, PortfolioId = portfolioId, SecurityId = securityId, OMS = OMS, TransactionType = transactionType });
            //Act
            var orders = _orderService.CreateOrders(list);
            //Assert
            Assert.AreEqual(orders.Count, expectedResult);
        }

        [TestCase(56, 4, 1, "AAA", "SELL", 0)]
        [TestCase(56, 7, 2, "BBB", "BUY", 0)]
        [TestCase(56, 2, 1, "AAA", "SELL", 1)]
        public void Test_OrderSecurityNotExists_CreateOrder(decimal nominal, int portfolioId, int securityId, string OMS, string transactionType, int expectedResult)
        {
            //Arrange
            var list = new List<Transaction>();
            list.Add(new Transaction() { Nominal = nominal, PortfolioId = portfolioId, SecurityId = securityId, OMS = OMS, TransactionType = transactionType });
            //Act
            var orders = _orderService.CreateOrders(list);
            //Assert
            Assert.AreEqual(orders.Count, expectedResult);
        }
        [TestCase(56, 1, 1, "AAA", "SELL", "OrderAAA")]
        [TestCase(56, 1, 2, "BBB", "BUY", "OrderBBB")]
        [TestCase(56, 1, 2, "CCC", "BUY", "OrderCCC")]

        public void Test_CreateProperOrderType_CreateOrder(decimal nominal, int portfolioId, int securityId, string OMS, string transactionType, string expectedResult)
        {
            //Arrange
            var list = new List<Transaction>();
            list.Add(new Transaction() { Nominal = nominal, PortfolioId = portfolioId, SecurityId = securityId, OMS = OMS, TransactionType = transactionType });
            //Act
            var orders = _orderService.CreateOrders(list);
            //Assert
            Assert.AreEqual(orders[OMS].First().GetType().Name, expectedResult);
        }
    }

    public class ServiceConfigurationTest : IServiceConfiguration
    {
        public string FolderSecurities { get; set; }
        public string FolderPortfolios { get; set; }
        public string FolderOrders { get; set; }

        public ServiceConfigurationTest()
        {
            FolderSecurities = "C:\\WellsFargo\\securities.csv";
            FolderPortfolios = "C:\\WellsFargo\\portfolios.csv";
            FolderOrders = "C:\\WellsFargoOutput\\";

        }
    }
}