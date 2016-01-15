namespace TheLondonClinic.Mvc.JsAppConfig
{
    public class JQueryJsConfigCodeBuilder : JsConfigCodeBuilderBase,
        IJsConfigCodeBuilder
    {
        private readonly string _objectName;

        public JQueryJsConfigCodeBuilder()
        {
            _objectName = "appConfig";
        }

        public JQueryJsConfigCodeBuilder(string objectName)
        {
            _objectName = objectName;
        }

        protected override string Template(string jsonObject)
        {
            return "$." + _objectName + " = { " + jsonObject + " };";
        }
    }
}