using System.Collections.Generic;
using System.Linq;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class GlobalJsConfigCodeBuilder : JsConfigCodeBuilderBase,
        IJsConfigCodeBuilder
    {
        private readonly string _objectName;

        public GlobalJsConfigCodeBuilder()
        {
            _objectName = "appConfig";
        }

        public GlobalJsConfigCodeBuilder(string objectName)
        {
            _objectName = objectName;
        }

        protected override string Template(string jsonObject)
        {
            return "window." + _objectName + " = { " + jsonObject + " };";
        }
    }
}