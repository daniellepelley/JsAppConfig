using System.Collections.Generic;
using System.Linq;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class JsConfigCodeBuilder : JsConfigCodeBuilderBase,
        IJsConfigCodeBuilder
    {
        protected override string Template(string jsonObject)
        {
            return "var appConfig = function() { return { " + jsonObject + " }; };";
        }
    }

    public abstract class JsConfigCodeBuilderBase
    {
        public string Generate(IDictionary<string, string> dictionary)
        {
            return Template(GenerateJsonObject(dictionary));
        }

        protected abstract string Template(string jsonObject);

        protected string GenerateJsonObject(IDictionary<string, string> dictionary)
        {
            return string.Join(
                ", ",
                dictionary.Select(x => string.Format(@"{0} : ""{1}""", x.Key, x.Value)));
        }
    }
}