using System.Collections.Generic;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public interface IJsConfigReader
    {
        IDictionary<string, string> Read();
    }
}
