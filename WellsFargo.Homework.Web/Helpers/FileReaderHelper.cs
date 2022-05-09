using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WellsFargo.Homework.Services;
using WellsFargo.Homework.Web.Exceptions;

namespace WellsFargo.Homework.Web.Helpers
{
    public class FileReaderHelper : IFileReaderHelper
    {
        public List<Transaction> ReadInstructionsFile(byte[] fileData, string fileName)
        {
            try
            {

                var records = new List<Transaction>();
                using (var ms = new MemoryStream(fileData))
                {
                    using (var reader = new StreamReader(ms, true))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        while (csv.Read())
                        {
                            var tran = new Transaction();
                            tran.SecurityId = int.Parse(csv.GetField("SecurityId"));
                            tran.PortfolioId = int.Parse(csv.GetField("PortfolioId"));
                            tran.Nominal = decimal.Parse(csv.GetField("Nominal"));
                            tran.OMS = csv.GetField("OMS");
                            tran.TransactionType =csv.GetField("TransactionType");
                            records.Add(tran);

                        }
                        return records;
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidFileException("File is invalid");
            }
        }
    }
}
