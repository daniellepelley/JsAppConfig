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
    }
}