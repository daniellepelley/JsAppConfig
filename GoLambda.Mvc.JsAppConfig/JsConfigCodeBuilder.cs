using System.Collections.Generic;
using System.Linq;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class JsConfigCodeBuilder : IJsConfigCodeBuilder
    {
        public string Generate(IDictionary<string, string> dictionary)
        {
            var jsProperties = string.Join(
                ", ",
                dictionary.Select(x => string.Format("{0} : '{1}'", x.Key, x.Value)));

            return "var appConfig = function() { return { " + jsProperties + " }; };";
        }
    }
}