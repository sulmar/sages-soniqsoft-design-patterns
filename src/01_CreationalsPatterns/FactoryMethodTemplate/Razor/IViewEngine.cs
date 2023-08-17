using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
    // Abstract Product
    public interface IViewEngine
    {
        string Render(string viewName, IDictionary<string, object> context);
    }
}