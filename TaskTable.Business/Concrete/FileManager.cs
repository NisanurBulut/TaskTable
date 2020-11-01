using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TaskTable.Business.Interfaces;

namespace TaskTable.Business.Concrete
{
    public class FileManager : IFileService
    {
        public byte[] ExportExcel<T>(List<T> entity) where T : class, new()
        {
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add("Calisma1");
            excelBlank.Cells["A1"].LoadFromCollection(entity, true, OfficeOpenXml.Table.TableStyles.Light15);
            return excelPackage.GetAsByteArray();
        }
        public string ExportPdf<T>(List<T> entity) where T : class, new()
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(ObjectReader.Create(entity));

            var fileName = Guid.NewGuid() + ".pdf";
            var returnPath = "/documents" + fileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot/documents/" + fileName);
            var stream = new FileStream(path, FileMode.Open);
            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            PdfPTable pdfTable = new PdfPTable(dataTable.Columns.Count);
            for (int i=0; i< dataTable.Columns.Count; i++)
            {
                pdfTable.AddCell(dataTable.Columns[i].ColumnName);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfTable.AddCell(dataTable.Rows[i][j].ToString());
                }
            }
            document.Add(pdfTable);
            document.Close();
            return returnPath;
        }
    }
}
