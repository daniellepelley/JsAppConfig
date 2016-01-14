using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class AppConfigComponent
    {
        private readonly IJsConfigCodeBuilder _jsConfigCodeBuilder;
        private readonly IJsConfigReader _jsConfigReader;
        private readonly Func<IDictionary<string, object>, Task> _appFunc;

        public AppConfigComponent(Func<IDictionary<string, object>, Task> appFunc)
            : this(new JsConfigCodeBuilder(), new JsConfigReader())
        {
            _appFunc = appFunc;
        }

        public AppConfigComponent(IJsConfigCodeBuilder jsConfigCodeBuilder, IJsConfigReader jsConfigReader)
        {
            _jsConfigReader = jsConfigReader;
            _jsConfigCodeBuilder = jsConfigCodeBuilder;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var owinContext = new OwinContext(environment);

            if (!IsConfigRequest(owinContext) ||
                owinContext.Response.Body == null)
            {
                await _appFunc.Invoke(environment);
            }
            else
            {
                owinContext.Response.ContentType = "application/javascript";

                using (var writer = new StreamWriter(owinContext.Response.Body))
                {
                    var dictionary = _jsConfigReader.Read();
                    var javascript = _jsConfigCodeBuilder.Generate(dictionary);
                    await writer.WriteAsync(javascript);
                }
            }
        }

        private static bool IsConfigRequest(OwinContext owinContext)
        {
            var path = owinContext.Request.Path.Value;
            return !string.IsNullOrEmpty(path) && path.ToLower() == "/appconfig";
        }
    }
}