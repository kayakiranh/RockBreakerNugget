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
        /// DateTime format for database. yyyy-MM-dd
        /// </summary>
        /// <param name="val">String value</param>
        /// <returns>2023-04-25</returns>
        public static string FormatDateTimeForDatabase(this string val)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(val);
                if (dateTime == DateTime.MinValue) return dateTime.ToString("yyyy-MM-dd");
                return dateTime.ToString("yyyy-MM-dd");
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// DateTime format for customer. dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="val">Datetime value</param>
        /// <param name="seperator">Seperator string value(/,\,-)</param>
        /// <returns>25/04/2023 19:03</returns>
        public static string FormatDateTimeForCustomer(this DateTime val, string seperator = "/")
        {
            if (val == DateTime.MinValue) return DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm").Replace("-", seperator);
            return val.ToString("dd-MM-yyyy HH:mm").Replace("-", seperator);
        }

        /// <summary>
        /// DateTime format for customer. dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="val">String value</param>
        /// <param name="seperator">Seperator string value(/,\,-)</param>
        /// <returns>25/04/2023 19:03</returns>
        public static string FormatDateTimeForCustomer(this string val, string seperator = "/")
        {
            try
            {
                DateTime dateTime = DateTime.Parse(val);
                if (dateTime == DateTime.MinValue) return dateTime.ToString("dd-MM-yyyy HH:mm").Replace("-", seperator);
                return dateTime.ToString("dd-MM-yyyy HH:mm").Replace("-", seperator);
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Format decimal for customer. 1,111,111.99 TL
        /// </summary>
        /// <param name="val">Decimal value</param>
        /// <param name="showCurrencyName">Currency Name choose</param>
        /// <param name="cultureInfo">CultureInfo class</param>
        /// <returns>1,111,111.99 TL</returns>
        public static string FormatDecimal(this decimal val, bool showCurrencyName = false, CultureInfo cultureInfo = null)
        {
            cultureInfo = new CultureInfo(cultureInfo == null ? "tr-TR" : cultureInfo.Name);
            RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);
            string withoutCurrencyName = string.Format(CultureInfo.CreateSpecificCulture(cultureInfo.Name), "{0:0,0.00}", val);
            return showCurrencyName ? $"{withoutCurrencyName} {regionInfo.ISOCurrencySymbol}" : withoutCurrencyName;
        }

        /// <summary>
        /// Format long to decimal for customer. 1,111,111.99 TL
        /// </summary>
        /// <param name="val">Int64 value</param>
        /// <param name="showCurrencyName">Currency Name choose</param>
        /// <param name="cultureInfo">CultureInfo class</param>
        /// <returns>1,111,111.99 TL</returns>
        public static string FormatDecimalFromLong(this long val, bool showCurrencyName = false, CultureInfo cultureInfo = null)
        {
            cultureInfo = new CultureInfo(cultureInfo == null ? "tr-TR" : cultureInfo.Name);
            RegionInfo regionInfo = new RegionInfo(cultureInfo.LCID);
            string stringVal = $"{val}.00";
            decimal decimalVal = Convert.ToDecimal(stringVal);

            string withoutCurrencyName = string.Format(CultureInfo.CreateSpecificCulture(cultureInfo.Name), "{0:0,0.00}", decimalVal);
            return showCurrencyName ? $"{withoutCurrencyName} {regionInfo.ISOCurrencySymbol}" : withoutCurrencyName;
        }
    }
}