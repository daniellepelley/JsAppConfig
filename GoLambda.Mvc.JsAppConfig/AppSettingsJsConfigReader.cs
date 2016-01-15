using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class AppSettingsJsConfigReader : IJsConfigReader
    {
        private readonly Func<string, bool> _keyFilterFunc;
        private readonly Func<string, string> _keyCleanupFunc;

        public AppSettingsJsConfigReader()
            : this(x => x.StartsWith("JS_"), x => x.Substring(3, x.Length - 3))
        { }

        public AppSettingsJsConfigReader(Func<string, bool> keyFilterFunc, Func<string, string> keyCleanupFunc)
        {
            if (keyCleanupFunc == null)
            {
                throw new ArgumentNullException("keyFilterFunc");
            }

            if (keyFilterFunc == null)
            {
                throw new ArgumentNullException("keyCleanupFunc");
            }
                
            _keyCleanupFunc = keyCleanupFunc;
            _keyFilterFunc = keyFilterFunc;
        }

        public IDictionary<string, string> Read()
        {
            return System.Configuration.ConfigurationManager.AppSettings
                .AllKeys
                .Where(_keyFilterFunc)
                .ToDictionary(
                    _keyCleanupFunc,
                    key => System.Configuration.ConfigurationManager.AppSettings[key]);
        }
    }
}