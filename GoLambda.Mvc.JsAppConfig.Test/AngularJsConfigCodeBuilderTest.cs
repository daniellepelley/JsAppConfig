using System.Collections.Generic;
using NUnit.Framework;

namespace TheLondonClinic.Mvc.JsAppConfig.Test
{
    public class AngularJsConfigCodeBuilderTest
    {
        [Test]
        public void GivenADictionaryOfConfigKeyPairsWhenGenerateIsCalledThenValidJavaScriptIsGenerated1()
        {
            var expected = @"angular.module(""app1"")"
                .NextLine(@"    .factory(""myconfigService"", function () {")
                .NextLine(@"        return { foo : ""bar"" }")
                .NextLine("});");

            var jsConfigCodeBuilder = new AngularJsConfigCodeBuilder("app1", "myconfigService");
            
            var dictionary = new Dictionary<string, string>
            {
                {"foo", "bar"}
            };

            var actual = jsConfigCodeBuilder.Generate(dictionary);
            Assert.AreEqual(expected, actual);
        }
    }
}