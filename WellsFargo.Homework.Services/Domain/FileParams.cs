using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellsFargo.Homework.Services.Domain
{
    public class FileParams
    {
        public string OMSId { get; set; }
        public string FileExtension { get; set; }
        public string FileDelimiter { get; set; }        
        public bool FileHeader { get; set; }

    }
}
