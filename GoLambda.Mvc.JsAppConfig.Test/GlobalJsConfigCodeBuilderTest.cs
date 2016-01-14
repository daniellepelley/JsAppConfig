using System.Collections.Generic;
using System.Text;
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

    public static class Extensions
    {
        public static string NextLine(this string source, string nextLine)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(source);
            stringBuilder.Append(nextLine);
            return stringBuilder.ToString();
        }
    }
}