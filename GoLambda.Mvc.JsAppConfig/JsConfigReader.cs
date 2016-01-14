using System.Collections.Generic;
using System.Linq;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class JsConfigReader : IJsConfigReader
    {
        public IDictionary<string, string> Read()
        {
            return System.Configuration.ConfigurationManager.AppSettings
                .AllKeys
                .Where(x => x.StartsWith("JS_"))
                .ToDictionary(key =>
                    key.Substring(3, key.Length - 3),
                    key => System.Configuration.ConfigurationManager.AppSettings[key]);
        }
    }
}