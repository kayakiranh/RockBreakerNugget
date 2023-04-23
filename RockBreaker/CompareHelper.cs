using Newtonsoft.Json;
using System;

namespace RockBreaker
{
    [Serializable]
    public static class CompareHelper
    {
        public static bool StringCompare(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrWhiteSpace(str1) || string.IsNullOrEmpty(str2) || string.IsNullOrWhiteSpace(str2)) return false;

            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }

        public static bool ObjectCompare(object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null) return false;

            string str1 = JsonConvert.SerializeObject(obj1);
            string str2 = JsonConvert.SerializeObject(obj2);

            return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
        }
    }
}
