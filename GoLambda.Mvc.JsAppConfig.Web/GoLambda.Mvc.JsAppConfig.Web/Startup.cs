using GoLambda.Mvc.JsAppConfig.Web;
using Microsoft.Owin;
using Owin;
using TheLondonClinic.Mvc.JsAppConfig;

[assembly: OwinStartup(typeof(Startup))]
namespace GoLambda.Mvc.JsAppConfig.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJsAppConfig(
                x => x
                    .WithPath("/angular").AsAngular1Service("app", "configService"),
                x => x
                    .WithPath("/global").AsGlobalJs("config"),
                x => x
                    .WithPath("/jquery").AsJQuery("config"));
        }
    }
}