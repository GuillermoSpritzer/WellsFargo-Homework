using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;

namespace WellsFargo.Homework.Services
{
    public class SecuritiesRepository : ISecuritiesRepository
    {
        private string securitiesFolder = @"C:\WellsFargo\Securities.csv";
        private  Dictionary<int, Security> SecuritiesDictionary {get;set;}

        public SecuritiesRepository(IServiceConfiguration configuration)
        {
            SecuritiesDictionary = new Dictionary<int, Security>();
            securitiesFolder = configuration.FolderSecurities;
            PopulateSecuritiesDictionary();
        }
        public Security GetSecurities(int id)
        {
            Security security = new Security();
            SecuritiesDictionary.TryGetValue(id, out security);
            return security;
        }
        private void PopulateSecuritiesDictionary()
        {
            using (var reader = new StreamReader(securitiesFolder))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var security = new Security();
                        security.SecurityId = int.Parse(csv.GetField("SecurityId"));
                        security.ISIN = csv.GetField("ISIN");
                        security.Ticker = csv.GetField("Ticker");
                        security.Cusip = csv.GetField("CUSIP");
                        SecuritiesDictionary.TryAdd(security.SecurityId, security);
                    }

                }
            }
        }

    }
}
