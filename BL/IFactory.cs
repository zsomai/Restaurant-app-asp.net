using tema2.Models;

namespace tema2.BL;

public interface IFactory<T>
{
    public T CreateExporter(string type);  
}

