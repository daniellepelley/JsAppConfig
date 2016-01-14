using System.Collections.Generic;
using NUnit.Framework;

namespace TheLondonClinic.Mvc.JsAppConfig.Test
{
    public class JsConfigCodeBuilderTest
    {
        [Test]
        public void GivenADictionaryOfConfigKeyPairsWhenGenerateIsCalledThenValidJavaScriptIsGenerated1()
        {
            var expected = "var appConfig = function() { return { foo : 'bar' }; };";

            IJsConfigCodeBuilder jsConfigCodeBuilder = new JsConfigCodeBuilder();

            var dictionary = new Dictionary<string, string>
            {
                { "foo", "bar"}
            };

            var actual = jsConfigCodeBuilder.Generate(dictionary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenADictionaryOfConfigKeyPairsWhenGenerateIsCalledThenValidJavaScriptIsGenerated2()
        {
            var expected = "var appConfig = function() { return { bar : 'foo' }; };";

            IJsConfigCodeBuilder jsConfigCodeBuilder = new JsConfigCodeBuilder();

            var dictionary = new Dictionary<string, string>
            {
                { "bar", "foo"}
            };

            var actual = jsConfigCodeBuilder.Generate(dictionary);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenADictionaryOfConfigKeyPairsWhenGenerateIsCalledThenValidJavaScriptIsGenerated3()
        {
            var expected = "var appConfig = function() { return { foo : 'bar', bar : 'foo' }; };";

            IJsConfigCodeBuilder jsConfigCodeBuilder = new JsConfigCodeBuilder();

            var dictionary = new Dictionary<string, string>
            {
                { "foo", "bar"},
                { "bar", "foo"}
            };

            var actual = jsConfigCodeBuilder.Generate(dictionary);

            Assert.AreEqual(expected, actual);
        }
    }
}