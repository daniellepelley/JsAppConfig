using System.Text;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class AngularJsConfigCodeBuilder : JsConfigCodeBuilderBase,
        IJsConfigCodeBuilder
    {
        private readonly string _serviceName;
        private readonly string _appName;

        public AngularJsConfigCodeBuilder()
        {
            _appName = "app";
            _serviceName = "configService";
        }

        public AngularJsConfigCodeBuilder(string appName, string serviceName)
        {
            _appName = appName;
            _serviceName = serviceName;
        }

        protected override string Template(string json)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(@"angular.module(""" + _appName + @""")");
            stringBuilder.AppendLine(@"    .factory(""" + _serviceName + @""", function () {");
            stringBuilder.AppendLine(@"        return { " + json + " }");
            stringBuilder.Append(@"});");
            return stringBuilder.ToString();
        }
    }
}