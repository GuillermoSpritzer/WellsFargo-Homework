using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo.Homework.Services;
using WellsFargo.Homework.Web.Exceptions;
using WellsFargo.Homework.Web.Helpers;
using WellsFargo.Homework.Web.Model;

namespace WellsFargo.Homework.Web.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class FileController : ControllerBase
    {
        public  IFileReaderHelper _fileReaderHelper;
        public IOrderService _orderService;
        public IExportService _exportService;

        public FileController(IFileReaderHelper fileReaderHelper, IOrderService orderService, IExportService exportService)
        {
            _fileReaderHelper = fileReaderHelper;
            _orderService = orderService;
            _exportService = exportService;
        }


        [HttpPost]
        public ActionResult Post([FromForm] TransactionFile file)
        {
            try
            {
                if (file.FormFile == null)
                {
                    return BadRequest("Error: Please upload a File ");
                }
                var stringBuilder = new StringBuilder();
                var instructions = _fileReaderHelper.ReadInstructionsFile(file.ConvertToByteArray(), file.FileName);
                var orders = _orderService.CreateOrders(instructions);
                var fileLocations = _exportService.Export(orders, file.FileName);
                stringBuilder.AppendLine(fileLocations);
                return Ok(stringBuilder.ToString());
            }
            catch (InvalidFileException e)
            {
                return BadRequest("Error: Invalid File. Please upload a .csv file with the following columns : SecurityID,PortfolioId,Nominal,OMS,TransactionType ");
            }
        }
    }
}
