using System.Text;

namespace TheLondonClinic.Mvc.JsAppConfig.Test
{
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