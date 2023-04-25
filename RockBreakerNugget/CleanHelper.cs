using System;
using System.Text.RegularExpressions;

namespace RockBreakerNugget
{
    [Serializable]
    public static class CleanHelper
    {
        /// <summary>
        /// Remove html tags from string value.
        /// </summary>
        /// <param name="val">String value</param>
        /// <returns>String value</returns>
        public static string RemoveHtmlTags(this string val)
        {
            val = val.Trim();
            val = Regex.Replace(val, "<.*?>", String.Empty);
            val = val.Replace("\r", "");
            val = val.Replace("\n", "");
            val = Regex.Replace(val, @"\s+", " ");
            val = val.Trim();
            return val;
        }

        /// <summary>
        /// Convert unicode to utf.
        /// </summary>
        /// <param name="val">String value</param>
        /// <returns>String value</returns>
        public static string ChangeUnicodes(this string val)
        {
            string str = System.Net.WebUtility.HtmlDecode(val);
            return str;
        }
    }
}