using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services.Domain;

namespace WellsFargo.Homework.Services
{
    public class ExportService : IExportService
    {
        public string basePath = @"C:\WellsFargoOutput\";

        public IFileParamsRepository _fileParamsRepository;

        public ExportService(IFileParamsRepository fileParamsRepository, IServiceConfiguration configuration)
        {
            _fileParamsRepository = fileParamsRepository;
            basePath = configuration.FolderOrders;
        }
        public string ExportCsv<T>(List<T> genericList, string fileName, FileParams filaParam)
        {
            var sb = new StringBuilder();
            var finalPath = Path.Combine(basePath, fileName  + filaParam.FileExtension);
            var header = "";
            var first = genericList.First();
            var info =first.GetType().GetProperties();
            try
            {
                if (!File.Exists(finalPath))
                {
                    var file = File.Create(finalPath);
                    file.Close();
                    if (filaParam.FileHeader)
                    {
                        foreach (var prop in info)
                        {
                            header += prop.Name + filaParam.FileDelimiter;
                        }
                        header = header.Substring(0, header.Length - 1);
                        sb.AppendLine(header);
                        TextWriter sw = new StreamWriter(finalPath, true);
                        sw.Write(sb.ToString());
                        sw.Close();
                    }
                    foreach (var obj in genericList)
                    {
                        sb = new StringBuilder();
                        var line = "";
                        foreach (var prop in info)
                        {
                            line += prop.GetValue(obj, null) + filaParam.FileDelimiter;
                        }
                        line = line.Substring(0, line.Length - 1);
                        sb.AppendLine(line);
                        TextWriter sw = new StreamWriter(finalPath, true);
                        sw.Write(sb.ToString());
                        sw.Close();
                    }
                    return "File Created in location: " + finalPath;
                }
                else
                {
                    return "Filename already exists in location: " + finalPath;
                }
            }
            catch
            {
                return "Could not create file";
            }
            
        }

        public string Export(Dictionary<string, List<Order>> orders, string fileName)
        {
            var stringBuilder = new StringBuilder();
            foreach (var list in orders)
            {
                var fileParams = _fileParamsRepository.getFileParams(list.Key);
                if(fileParams == null)
                {
                    stringBuilder.AppendLine("Could not find parameters for the specific OMS, please check these are loaded correctly.");
                    continue;
                }
                stringBuilder.AppendLine(ExportCsv(list.Value, fileName, _fileParamsRepository.getFileParams(list.Key)));
            }
            return stringBuilder.ToString() ;
        }
    }
}
