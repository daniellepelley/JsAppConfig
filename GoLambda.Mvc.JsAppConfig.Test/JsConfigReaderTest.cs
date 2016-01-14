using NUnit.Framework;

namespace TheLondonClinic.Mvc.JsAppConfig.Test
{
    public class JsConfigReaderTest
    {
        [Test]
        public void GivenAConfigWithJsConfigWhenReadIsCalledThenTheJsConfigKeysAreRead()
        {
            IJsConfigReader jsConfigReader = new JsConfigReader();
            var dictionary = jsConfigReader.Read();
            Assert.AreEqual("bar", dictionary["foo"]);
        }
    }
}