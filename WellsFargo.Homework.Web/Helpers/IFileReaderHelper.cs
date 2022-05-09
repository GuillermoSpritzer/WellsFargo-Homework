using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WellsFargo.Homework.Services;

namespace WellsFargo.Homework.Web.Helpers
{
    public interface IFileReaderHelper
    {
        public List<Transaction> ReadInstructionsFile(byte[] fileData, string fileName);
    }
}
