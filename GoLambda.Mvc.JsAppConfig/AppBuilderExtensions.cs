using System;
using System.Linq;
using Microsoft.Owin;
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

        public static void UseJsAppConfig<T>(
            this IAppBuilder app)
            where T : IJsConfigCodeBuilder
        {
            app.Use<AppConfigComponent<T>>();
        }
    }

    public class JsConfigSetup
    {
        public IJsConfigCodeBuilder ConfigCodeBuilder { get; private set; }
        public string Url { get; private set; }

        public JsConfigSetup WithPath(string url)
        {
            Url = url;
            return this;
        }

        public JsConfigSetup UsingCodeBuilder(IJsConfigCodeBuilder configCodeBuilder)
        {
            ConfigCodeBuilder = configCodeBuilder;
            return this;
        }
    }
}