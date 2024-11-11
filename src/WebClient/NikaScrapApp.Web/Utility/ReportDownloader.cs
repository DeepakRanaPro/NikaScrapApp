using System.Globalization;
using CsvHelper;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Document = iTextSharp.text.Document;
using System.Collections.Generic;
namespace NikaScrapApp.Web.Utility
{


    public class ReportModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
     
    public class ReportDownloader
    {
        public byte[] GenerateExcelReport(List<ReportModel> reportData)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");
                worksheet.Cells["A1"].Value = "ID";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "Date";

                for (int i = 0; i < reportData.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = reportData[i].Id;
                    worksheet.Cells[i + 2, 2].Value = reportData[i].Name;
                    worksheet.Cells[i + 2, 3].Value = reportData[i].Date.ToString("dd/MM/yyyy");
                }

                return package.GetAsByteArray();
            }
        }

        public byte[] GenerateCsvReport(List<ReportModel> reportData)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(reportData);
                streamWriter.Flush();
                return memoryStream.ToArray();
            }
        }

        public byte[] GeneratePdfReport(List<ReportModel> reportData)
        {
            using (var memoryStream = new MemoryStream())
            {
                var document = new Document();
                PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                var table = new PdfPTable(3);
                table.AddCell("ID");
                table.AddCell("Name");
                table.AddCell("Date");

                foreach (var item in reportData)
                {
                    table.AddCell(item.Id.ToString());
                    table.AddCell(item.Name);
                    table.AddCell(item.Date.ToString("dd/MM/yyyy"));
                }

                document.Add(table);
                document.Close();

                return memoryStream.ToArray();
            }
        }

        public byte[] GenerateWordReport(List<ReportModel> reportData)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var document = WordprocessingDocument.Create(memoryStream, WordprocessingDocumentType.Document, true))
                {
                    var mainPart = document.AddMainDocumentPart();
                    mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                    var body = new Body();
                    var table = new Table();

                    // Add header row
                    var headerRow = new TableRow();
                    headerRow.Append(new TableCell(new DocumentFormat.OpenXml.Drawing.Paragraph(new Run(new Text("ID")))));
                    headerRow.Append(new TableCell(new DocumentFormat.OpenXml.Drawing.Paragraph(new Run(new Text("Name")))));
                    headerRow.Append(new TableCell(new DocumentFormat.OpenXml.Drawing.Paragraph(new Run(new Text("Date")))));
                    table.Append(headerRow);

                    // Add data rows
                    foreach (var item in reportData)
                    {
                        var row = new TableRow();
                        row.Append(new TableCell(new DocumentFormat.OpenXml.Drawing.Paragraph(new Run(new Text(item.Id.ToString())))));
                        row.Append(new TableCell(new DocumentFormat.OpenXml.Drawing.Paragraph(new Run(new Text(item.Name)))));
                        row.Append(new TableCell(new DocumentFormat.OpenXml.Drawing.Paragraph(new Run(new Text(item.Date.ToString("dd/MM/yyyy"))))));
                        table.Append(row);
                    }

                    body.Append(table);
                    mainPart.Document.Append(body);
                    mainPart.Document.Save();
                }
                return memoryStream.ToArray();
            }
        }
    }

    public class GenericReportModel { public Dictionary<string, object> Data { get; set; } }
    public class GenericReportDownloader
    {
        public byte[] GenerateExcelReport(List<GenericReportModel> reportData)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Report"); 
                // Add header row
                var headers = reportData[0].Data.Keys; 
                int headerColumnIndex = 1; 
                foreach (var header in headers) 
                { 
                    worksheet.Cells[1, headerColumnIndex].Value = header; 
                    headerColumnIndex++; 
                } 
                
                // Add data rows
                for (int i = 0; i < reportData.Count; i++) 
                { 
                    int dataColumnIndex = 1;
                    foreach (var value in reportData[i].Data.Values) 
                    { 
                        worksheet.Cells[i + 2, dataColumnIndex].Value = value; 
                        dataColumnIndex++; 
                    } 
                } 

                return package.GetAsByteArray(); 
            } 
          }
     }
}
