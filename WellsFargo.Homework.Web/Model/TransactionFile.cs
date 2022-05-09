using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WellsFargo.Homework.Web.Model
{
    public class TransactionFile
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set; }

        public TransactionFile()
        {

        }

        public byte[] ConvertToByteArray()
        {
            using var ms = new MemoryStream();
            FormFile.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
