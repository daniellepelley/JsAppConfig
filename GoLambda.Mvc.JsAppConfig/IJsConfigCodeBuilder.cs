using System.Collections.Generic;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public interface IJsConfigCodeBuilder
    {
        string Generate(IDictionary<string, string> dictionary);
    }
}