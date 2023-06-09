using Microsoft.AspNetCore.Mvc;
using tema2.Utils;

namespace tema2.BL;

public interface IExporter
{
    public IActionResult export(ViewOrder order);  
}

