using CsvHelper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;


namespace WellsFargo.Homework.Services
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private string portfolioFolder;
        private Dictionary<int, Portfolio> PortfolioDictionary { get; set; }

        public PortfolioRepository(IServiceConfiguration configuration)
        {
            PortfolioDictionary = new Dictionary<int, Portfolio>();
            portfolioFolder = configuration.FolderPortfolios;
            PopulatePortfolioDictionary();
        }

        public Portfolio GetPortfolio(int id)
        {
            Portfolio portfolio = new Portfolio();
            PortfolioDictionary.TryGetValue(id, out portfolio);
            return portfolio;
        }
        private void PopulatePortfolioDictionary()
        {
            using (var reader = new StreamReader(portfolioFolder))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var portfolio = new Portfolio();
                        portfolio.PortfolioId = int.Parse(csv.GetField("PortfolioId"));
                        portfolio.PortfolioCode = csv.GetField("PortfolioCode");
                        PortfolioDictionary.TryAdd(portfolio.PortfolioId, portfolio);
                    }

                }
            }
        }
    }

}
