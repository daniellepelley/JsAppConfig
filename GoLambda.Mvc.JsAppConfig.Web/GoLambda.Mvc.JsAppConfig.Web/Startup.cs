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
            app.UseJsAppConfig(x => x
                .WithPath("/angular")
                .UsingCodeBuilder(new AngularJsConfigCodeBuilder("app", "configService")),
                x => x
                .WithPath("/global")
                .UsingCodeBuilder(new GlobalJsConfigCodeBuilder("config")),
                x => x
                .WithPath("/function")
                .UsingCodeBuilder(new JsConfigCodeBuilder()),
                x => x
                .WithPath("/jquery")
                .UsingCodeBuilder(new JQueryJsConfigCodeBuilder("config"))
                );
        }
    }
}