using NUnit.Framework;

namespace TheLondonClinic.Mvc.JsAppConfig.Test
{
    public class JsConfigReaderTest
    {
        [Test]
        public void GivenAConfigWithJsConfigWhenReadIsCalledThenTheJsConfigKeysAreRead()
        {
            IJsConfigReader jsConfigReader = new AppSettingsJsConfigReader();
            var dictionary = jsConfigReader.Read();
            Assert.AreEqual("bar", dictionary["foo"]);
        }
    }
}