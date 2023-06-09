using System.Text;
using Microsoft.AspNetCore.Mvc;
using tema2.Utils;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace tema2.BL;

public class ExportXlsx : IExporter
{
    public IActionResult export(ViewOrder order)
    {
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Order");
            worksheet.Cells["A1"].Value = "Name";
            worksheet.Cells["B1"].Value = "Stock";
            worksheet.Cells["C1"].Value = "Quantity";
            worksheet.Cells["D1"].Value = "Price";
            worksheet.Cells["E1"].Value = "Total";

            using (var headerRange = worksheet.Cells["A1:E1"])
            {
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            }

            int rowNum = 2;

            foreach (var item in order.Meals)
            {
                worksheet.Cells[rowNum, 1].Value = item.Item1.Name;
                worksheet.Cells[rowNum, 2].Value = item.Item1.Stock;
                worksheet.Cells[rowNum, 3].Value = item.Item2;
                worksheet.Cells[rowNum, 4].Value = item.Item1.Price;
                worksheet.Cells[rowNum, 5].Value = item.Item1.Price * item.Item2;
                rowNum++;
            }

            return new FileContentResult(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "order.xlsx"
            };
        }
    }


}

