using Microsoft.AspNetCore.Mvc;
using NikaScrapApp.Web.Utility;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
namespace NikaScrapApp.Web.Controllers
{ 
    public class ReportController : Controller
    {
        private readonly GenericReportDownloader _reportDownloader;

        public ReportController()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            _reportDownloader = new GenericReportDownloader();
        }

        public ActionResult Index()
        {
            var reportData = GetGenericReportData();
            return View(reportData);
        }

        [HttpPost]
        public ActionResult ExportToExcel()
        {
            var reportData = GetGenericReportData();
            var excelBytes = _reportDownloader.GenerateExcelReport(reportData);

            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Report.xlsx");
        }

        private List<GenericReportModel> GetGenericReportData()
        {
            // Mock data for demonstration
            return new List<GenericReportModel>
        {
            new GenericReportModel { Data = new Dictionary<string, object>
                {
                    { "ID", 1 },
                    { "Name", "John Doe" },
                    { "Date", DateTime.Now.ToString("dd/MM/yyyy") }
                }
            },
            new GenericReportModel { Data = new Dictionary<string, object>
                {
                    { "ID", 2 },
                    { "Name", "Jane Smith" },
                    { "Date", DateTime.Now.ToString("dd/MM/yyyy") }
                }
            }
        };
        }
    }

}
