using Newtonsoft.Json;
using System;
using System.Linq;

namespace RockBreakerNugget
{
    [Serializable]
    public static class CompareHelper
    {
        /// <summary>
        /// Compare 2 string
        /// </summary>
        /// <param name="str1">String value</param>
        /// <param name="str2">String value</param>
        /// <returns>True/False</returns>
        public static bool StringCompare(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrWhiteSpace(str1) || string.IsNullOrEmpty(str2) || string.IsNullOrWhiteSpace(str2)) return false;

            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compare 2 object
        /// </summary>
        /// <param name="obj1">Object value</param>
        /// <param name="obj2">Object value</param>
        /// <returns>True/False</returns>
        public static bool ObjectCompare(object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null) return false;

            string str1 = JsonConvert.SerializeObject(obj1);
            string str2 = JsonConvert.SerializeObject(obj2);

            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compare 2 array
        /// </summary>
        /// <param name="arr1">Array value</param>
        /// <param name="arr2">Array value</param>
        /// <returns>True/False</returns>
        public static bool ArrayCompare(Array[] arr1, Array[] arr2)
        {
            if (arr1 == null && arr2 == null)
                return true;
            if (arr1 == null || arr2 == null)
                return false;
            if (arr1.Length != arr2.Length)
                return false;
            return !arr1.Except(arr2).Any() && !arr2.Except(arr1).Any();
        }
    }
}
