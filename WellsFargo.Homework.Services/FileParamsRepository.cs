using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;

namespace WellsFargo.Homework.Services
{
    public class FileParamsRepository : IFileParamsRepository
    {
        private Dictionary<string,FileParams> FileParamsDictionary { get; set; }

        public FileParams getFileParams(string id)
        {
            FileParams fileParams = new FileParams();
            FileParamsDictionary.TryGetValue(id, out fileParams);
            return fileParams;
        }

        public FileParamsRepository()
        {
            FileParamsDictionary = new Dictionary<string, FileParams>();
            FileParamsDictionary.Add("AAA", new FileParams() { FileDelimiter = ",", FileExtension = ".aaa", FileHeader = true });
            FileParamsDictionary.Add("BBB", new FileParams() { FileDelimiter = "|", FileExtension = ".bbb", FileHeader = true });
            FileParamsDictionary.Add("CCC", new FileParams() { FileDelimiter = ",", FileExtension = ".ccc", FileHeader = false });
        }

    }
}
