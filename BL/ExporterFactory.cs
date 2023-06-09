
namespace tema2.BL;

public class ExporterFactory : IFactory<IExporter>
{

    private static ExporterFactory instance;

    private Dictionary<string, Func<IExporter>> exporterCreationMap;

    public ExporterFactory()
    {
        exporterCreationMap = new Dictionary<string, Func<IExporter>>();
        exporterCreationMap.Add("ExportCsv", () => new ExportCsv());
        exporterCreationMap.Add("ExportXlsx", () => new ExportXlsx());
    }

    public IExporter CreateExporter(string type)
    {
        if (exporterCreationMap.ContainsKey(type))
        {
            Func<IExporter> exporterCreationFunc = exporterCreationMap[type];
            IExporter exporter = exporterCreationFunc.Invoke();
            return exporter;
        }

        throw new ArgumentException("Invalid product type.");
    }



    public static IFactory<IExporter> Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ExporterFactory();
            }
            return instance;
        }
    }
}