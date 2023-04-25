using Ganss.Xss;
using System;
using System.Collections;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RockBreakerNugget
{
    [Serializable]
    public static class ValidationHelper
    {
        /// <summary>
        /// String validation. Check null or empty
        /// </summary>
        /// <param name="val">String value</param>
        /// <returns>Value/string.Empty</returns>
        public static string StringValidation(this string val)
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;
            val = Regex.Replace(val, @"\s+", "");
            val = val.Trim();
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;

            return val;
        }

        /// <summary>
        /// Int32 validation. Check zero or minus
        /// </summary>
        /// <param name="val">Int32 value</param>
        /// <returns>Value/0</returns>
        public static int IntValidation(this int val)
        {
            return val < 1 ? 0 : val;
        }

        /// <summary>
        /// Int64 validation. Check zero or minus
        /// </summary>
        /// <param name="val">Int64 value</param>
        /// <returns>Value/0</returns>
        public static long LongValidation(this long val)
        {
            return val < 1 ? 0 : val;
        }

        /// <summary>
        /// Decimal validation. Check zero or minus
        /// </summary>
        /// <param name="val">Decimal value</param>
        /// <returns>Value/0</returns>
        public static decimal DecimalValidation(this decimal val)
        {
            return val < decimal.One ? decimal.Zero : val;
        }

        /// <summary>
        /// List validation. Check list count
        /// </summary>
        /// <param name="val">Object value</param>
        /// <returns>True/False</returns>
        public static bool ListValidation(this object val)
        {
            IEnumerable? enumerable = val as IEnumerable;
            if (enumerable == null) return false;

            return enumerable.Cast<Object>().Any();
        }

        /// <summary>
        /// Mail address validation
        /// </summary>
        /// <param name="val">Mail address</param>
        /// <returns>Value/string.Empty</returns>
        public static string MailAddressValidation(this string val)
        {
            try
            {
                MailAddress emailAddress = new MailAddress(val);
                return emailAddress.Address;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Security validation. Clear dangerous parts from string value. Use Ganss.Xss, HtmlSanitizer
        /// </summary>
        /// <param name="val">String value</param>
        /// <returns>Value</returns>
        public static string SecurityValidation(this string val)
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;
            val = Regex.Replace(val, @"\s+", "");
            val = val.Trim();
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;

            val = Regex.Replace(val, "<.*?>", string.Empty);
            HtmlSanitizer htmlSanitizer = new HtmlSanitizer();
            return htmlSanitizer.Sanitize(val);
        }

        /// <summary>
        /// Phone validation
        /// </summary>
        /// <param name="val">Phone number</param>
        /// <param name="startFormat">Start format</param>
        /// <returns>Value/string.Empty</returns>
        public static string PhoneValidation(this string val, string startFormat = "+90")
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;
            val = Regex.Replace(val, @"\s+", "");
            val = val.Trim();
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;

            if (val.StartsWith("+90")) val = val.Remove(0, 3);
            if (val.StartsWith("90")) val = val.Remove(0, 2);
            if (val.StartsWith("0")) val = val.Remove(0, 1);

            int count = val.Count(x => char.IsDigit(x));
            if (count == 10) val = startFormat + val;

            return val;
        }

        /// <summary>
        /// Url validation. Basic metod
        /// </summary>
        /// <param name="val">Url</param>
        /// <returns>True/False</returns>
        public static bool UrlValidation(this string val)
        {
            return Uri.IsWellFormedUriString(val, UriKind.Absolute);
        }

        /// <summary>
        /// Url validation. Best practice is send request to url.
        /// </summary>
        /// <param name="val">Url</param>
        /// <returns>True/False</returns>
        public static async Task<bool> UrlValidationWithClient(this string val)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(val),
                    Method = HttpMethod.Head
                };
                HttpResponseMessage sendResponse = await httpClient.SendAsync(request);
                return sendResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Identity validation
        /// </summary>
        /// <param name="val">TC kimlik no</param>
        /// <returns>True/False</returns>
        public static bool TcKimlikNoValidation(this string val)
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return false;
            val = Regex.Replace(val, @"\s+", "");
            val = val.Trim();
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return false;
            if (val.Length != 11 && val.Count(x => Char.IsDigit(x)) != 11) return false;

            long ATCNO, BTCNO, TcNo;
            long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

            TcNo = long.Parse(val);

            ATCNO = TcNo / 100;
            BTCNO = TcNo / 100;

            C1 = ATCNO % 10; ATCNO /= 10;
            C2 = ATCNO % 10; ATCNO /= 10;
            C3 = ATCNO % 10; ATCNO /= 10;
            C4 = ATCNO % 10; ATCNO /= 10;
            C5 = ATCNO % 10; ATCNO /= 10;
            C6 = ATCNO % 10; ATCNO /= 10;
            C7 = ATCNO % 10; ATCNO /= 10;
            C8 = ATCNO % 10; ATCNO /= 10;
            C9 = ATCNO % 10;
            Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
            Q2 = ((10 - ((((C2 + C4 + C6 + C8 + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

            return (BTCNO * 100) + (Q1 * 10) + Q2 == TcNo;
        }
    }
}