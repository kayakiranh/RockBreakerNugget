using System;
using System.Globalization;

namespace RockBreakerNugget
{
    [Serializable]
    public static class FormatHelper
    {
        /// <summary>
        /// DateTime format for database. yyyy-MM-dd
        /// </summary>
        /// <param name="val">DateTime value</param>
        /// <returns>2023-04-25</returns>
        public static string FormatDateTimeForDatabase(this DateTime val)
        {
            if (val == DateTime.MinValue) return DateTime.UtcNow.ToString("yyyy-MM-dd");
            return val.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// DateTime format for customer. dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="val">Datetime value</param>
        /// <param name="seperator">Seperator string value(/,\,-)</param>
        /// <returns>25/04/2023 19:03</returns>
        public static string FormatDateTimeForCustomer(DateTime val, string seperator = "/")
        {
            if (val == DateTime.MinValue) return DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm").Replace("-", seperator);
            return val.ToString("dd-MM-yyyy HH:mm").Replace("-", seperator);
        }

        /// <summary>
        /// Format decimal for customer. 1,111,111.99 TL
        /// </summary>
        /// <param name="val"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>1,111,111.99 TL</returns>
        public static string FormatDecimal(this decimal val, CultureInfo cultureInfo = null)
        {
            string withoutCurrencyName = string.Format(CultureInfo.CreateSpecificCulture(cultureInfo.Name), "{0:0,0.00}", val);
            return cultureInfo != null ? withoutCurrencyName : $"{withoutCurrencyName} {cultureInfo.NumberFormat.CurrencySymbol}";
        }

        /// <summary>
        /// Format long to decimal for customer. 1,111,111.99 TL
        /// </summary>
        /// <param name="val"></param>
        /// <param name="cultureInfo"></param>
        /// <returns>1,111,111.99 TL</returns>
        public static string FormatDecimalFromLong(this long val, CultureInfo cultureInfo = null)
        {
            string stringVal = $"{val}.00";
            decimal decimalVal = Convert.ToDecimal(stringVal);
            string withoutCurrencyName = string.Format(CultureInfo.CreateSpecificCulture(cultureInfo.Name), "{0:0,0.00}", decimalVal);
            return cultureInfo != null ? withoutCurrencyName : $"{withoutCurrencyName} {cultureInfo.NumberFormat.CurrencySymbol}";
        }
    }
}