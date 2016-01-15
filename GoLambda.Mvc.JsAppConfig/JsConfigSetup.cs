namespace TheLondonClinic.Mvc.JsAppConfig
{
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