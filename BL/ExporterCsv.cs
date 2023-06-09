using System.Text;
using Microsoft.AspNetCore.Mvc;
using tema2.Utils;

namespace tema2.BL;

public class ExportCsv : IExporter
{
    public IActionResult export(ViewOrder order)
    {
        var builder = new StringBuilder();
        builder.AppendLine("name,stock,quantity,price,total");
        foreach(var item in order.Meals)
        {
            builder.AppendLine(item.Item1.Name + "," + item.Item1.Stock.ToString() + "," + item.Item2.ToString() + "," + item.Item1.Price.ToString() + "," + (item.Item1.Price * item.Item2).ToString());
        }


        return new FileContentResult(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv")
        {
            FileDownloadName = "order.csv"
        };

    }        
}

