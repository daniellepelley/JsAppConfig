using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class AppConfigComponent
    {
        private readonly Dictionary<string, IJsConfigCodeBuilder> _dictionary = new Dictionary<string, IJsConfigCodeBuilder>();

        protected readonly IJsConfigReader JsConfigReader;
        protected readonly Func<IDictionary<string, object>, Task> AppFunc;

        //public AppConfigComponent(Func<IDictionary<string, object>, Task> appFunc, IJsConfigCodeBuilder jsConfigCodeBuilder, IJsConfigReader jsConfigReader)
        //{
        //    AppFunc = appFunc;
        //    JsConfigReader = jsConfigReader;
        //    _dictionary.Add("/appconfig", jsConfigCodeBuilder);
        //}

        //public AppConfigComponent(Func<IDictionary<string, object>, Task> appFunc)
        //    : this(appFunc, new JsConfigCodeBuilder(), new JsConfigReader())
        //{}

        public AppConfigComponent(Func<IDictionary<string, object>, Task> appFunc, IEnumerable<JsConfigSetup> setups)
        {
            AppFunc = appFunc;
            JsConfigReader = new JsConfigReader();

            foreach (var setup in setups)
            {
                _dictionary.Add(setup.Url, setup.ConfigCodeBuilder);
            }
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var owinContext = new OwinContext(environment);
            var path = owinContext.Request.Path.Value;

            if (!IsConfigRequest(path) ||
                owinContext.Response.Body == null)
            {
                await AppFunc.Invoke(environment);
            }
            else
            {
                owinContext.Response.ContentType = "application/javascript";

                using (var writer = new StreamWriter(owinContext.Response.Body))
                {
                    var dictionary = JsConfigReader.Read();
                    var javascript = _dictionary[path.ToLower()].Generate(dictionary);
                    await writer.WriteAsync(javascript);
                }
            }
        }

        private bool IsConfigRequest(string path)
        {
            return !string.IsNullOrEmpty(path) && _dictionary.ContainsKey(path.ToLower());
        }
    }
}