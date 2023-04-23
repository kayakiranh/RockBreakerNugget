using Ganss.Xss;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RockBreaker
{
    [Serializable]
    public static class PasswordHelper
    {
        private static string ConvertSha256(string val)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding encoding = Encoding.UTF8;
                foreach (byte b in hash.ComputeHash(encoding.GetBytes(val))) stringBuilder.Append(b.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public static string Encrypt(this string val, string saltValue)
        {
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;
            val = Regex.Replace(val, @"\s+", "");
            val = val.Trim();
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;

            if (val.SecurityValidation()?.Length == 0) return string.Empty;

            HtmlSanitizer htmlSanitizer = new HtmlSanitizer();
            val = htmlSanitizer.Sanitize(val);
            if (string.IsNullOrEmpty(val) || string.IsNullOrWhiteSpace(val)) return string.Empty;

            if (string.IsNullOrEmpty(saltValue) || string.IsNullOrWhiteSpace(saltValue)) return string.Empty;
            saltValue = Regex.Replace(saltValue, @"\s+", "");
            saltValue = saltValue.Trim();
            if (string.IsNullOrEmpty(saltValue) || string.IsNullOrWhiteSpace(saltValue)) return string.Empty;

            if (saltValue.SecurityValidation()?.Length == 0) return string.Empty;

            saltValue = htmlSanitizer.Sanitize(saltValue);
            if (string.IsNullOrEmpty(saltValue) || string.IsNullOrWhiteSpace(saltValue)) return string.Empty;

            string salt = ConvertSha256(saltValue);
            string pass = ConvertSha256(val);
            return ConvertSha256(salt + pass);
        }
    }
}
