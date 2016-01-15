using System;
using System.Linq;
using Owin;

namespace TheLondonClinic.Mvc.JsAppConfig
{
    public static class AppBuilderExtensions
    {
        public static void UseJsAppConfig(
            this IAppBuilder app)
        {
            app.Use<AppConfigComponent>();
        }

        public static void UseJsAppConfig(
            this IAppBuilder app, params Action<JsConfigSetup>[] actions)
        {
            var setups = actions.Select(action =>
            {
                var setup = new JsConfigSetup();
                action(setup);
                return setup;
            });

            app.Use<AppConfigComponent>(setups);
        }


        public static JsConfigSetup AsAngular1Service(this JsConfigSetup setup, string appName, string serviceName)
        {
            setup.UsingCodeBuilder(new AngularJsConfigCodeBuilder(appName, serviceName));
            return setup;
        }

        public static JsConfigSetup AsGlobalJs(this JsConfigSetup setup, string objectName)
        {
            setup.UsingCodeBuilder(new GlobalJsConfigCodeBuilder(objectName));
            return setup;
        }

        public static JsConfigSetup AsJQuery(this JsConfigSetup setup, string objectName)
        {
            setup.UsingCodeBuilder(new JQueryJsConfigCodeBuilder(objectName));
            return setup;
        }
    }
}