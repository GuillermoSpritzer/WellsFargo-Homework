using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Web.Helpers;

namespace WellsFargo.Homework.Services.Tests
{
    [TestFixture]
    public class TestFileReader
    {
        public string fullpath = "..\\..\\..\\TestFiles\\transactions.csv";

        public FileReaderHelper fileReaderHelper;

        [SetUp]
        public void Setup()
        {
            fileReaderHelper = new FileReaderHelper();
        }


        [Test]
        public void Test_CorrectTransactionImport_ReadInstructionsFile()
        {
            //Arrange
            var file = File.ReadAllBytes(Path.GetFullPath(fullpath));

            //Act
            var transactions = fileReaderHelper.ReadInstructionsFile(file, "TestName");

            //Assert
            Assert.AreEqual(transactions[0].Nominal, 10);
            Assert.AreEqual(transactions[0].OMS, "AAA");
            Assert.AreEqual(transactions[0].TransactionType, "BUY");
            Assert.AreEqual(transactions[0].SecurityId, 1);
            Assert.AreEqual(transactions[0].PortfolioId, 1);
            //-------
            Assert.AreEqual(transactions[1].Nominal, 20);
            Assert.AreEqual(transactions[1].OMS, "BBB");
            Assert.AreEqual(transactions[1].TransactionType, "SELL");
            Assert.AreEqual(transactions[1].SecurityId, 2);
            Assert.AreEqual(transactions[1].PortfolioId, 2);

        }
    }
}
