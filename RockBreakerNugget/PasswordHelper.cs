using Ganss.Xss;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace RockBreakerNugget
{
    [Serializable]
    public static class PasswordHelper
    {
        /// <summary>
        /// Convert string to sha256
        /// </summary>
        /// <param name="val">Password value</param>
        /// <returns>Sha256 value</returns>
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

        /// <summary>
        /// Encrypt string. Method use salt + hash. Salt value must fill.
        /// </summary>
        /// <param name="password">Password value</param>
        /// <param name="saltValue">Salt value</param>
        /// <returns>Salt+Hash password</returns>
        public static string Encrypt(this string password, string saltValue)
        {
            //check password
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)) return string.Empty;
            password = Regex.Replace(password, @"\s+", "");
            password = password.Trim();
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)) return string.Empty;

            if (password.SecurityValidation()?.Length == 0) return string.Empty;

            HtmlSanitizer htmlSanitizer = new HtmlSanitizer();
            password = htmlSanitizer.Sanitize(password);
            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password)) return string.Empty;

            //check salt
            if (string.IsNullOrEmpty(saltValue) || string.IsNullOrWhiteSpace(saltValue)) return string.Empty;
            saltValue = Regex.Replace(saltValue, @"\s+", "");
            saltValue = saltValue.Trim();
            if (string.IsNullOrEmpty(saltValue) || string.IsNullOrWhiteSpace(saltValue)) return string.Empty;

            if (saltValue.SecurityValidation()?.Length == 0) return string.Empty;

            saltValue = htmlSanitizer.Sanitize(saltValue);
            if (string.IsNullOrEmpty(saltValue) || string.IsNullOrWhiteSpace(saltValue)) return string.Empty;

            //Encyrpt
            string salt = ConvertSha256(saltValue);
            string pass = ConvertSha256(password);
            return ConvertSha256(salt + pass);
        }

        /// <summary>
        /// Generate random password
        /// </summary>
        /// <param name="passwordLength">Password length</param>
        /// <param name="specialChar">Special char choose</param>
        /// <returns>Password</returns>
        public static string RandomPassword(int passwordLength = 10, bool specialChar = false)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            const string specialChars = "!^+%&(){[]}=?-_,;:.|<>@*!^+%&(){[]}=?-_,;:.|<>@*";

            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < passwordLength--)
            {
                res.Append(res.Append(rnd.Next(1, 2) % 2 == 0 ? specialChars[rnd.Next(specialChars.Length)] : validChars[rnd.Next(validChars.Length)]));
            }
            return res.ToString();
        }
    }
}