using System.Collections.Generic;
using NUnit.Framework;

namespace TheLondonClinic.Mvc.JsAppConfig.Test
{
    public class GlobalJsConfigCodeBuilderTest
    {
        [Test]
        public void GivenADictionaryOfConfigKeyPairsWhenGenerateIsCalledThenValidJavaScriptIsGenerated1()
        {
            var expected = @"window.appConfig = { foo : ""bar"" };";

            var jsConfigCodeBuilder = new GlobalJsConfigCodeBuilder();

            var dictionary = new Dictionary<string, string>
            {
                {"foo", "bar"}
            };

            var actual = jsConfigCodeBuilder.Generate(dictionary);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenADictionaryOfConfigKeyPairsWhenGenerateIsCalledThenValidJavaScriptIsGenerated2()
        {
            var expected = @"window.foo = { foo : ""bar"" };";

            var jsConfigCodeBuilder = new GlobalJsConfigCodeBuilder("foo");

            var dictionary = new Dictionary<string, string>
            {
                {"foo", "bar"}
            };

            var actual = jsConfigCodeBuilder.Generate(dictionary);
            Assert.AreEqual(expected, actual);
        }
    }
}