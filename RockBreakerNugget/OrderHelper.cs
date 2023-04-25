using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RockBreakerNugget
{
    [Serializable]
    public static class OrderHelper
    {
        /// <summary>
        /// Sort dynamic list. Method can sort any list.
        /// </summary>
        /// <param name="obj">List value</param>
        /// <param name="orderByDescending">OrderByDescending choose</param>
        /// <param name="propertyName">Propery name</param>
        /// <returns>List<dynamic>/Original List</returns>
        public static object OrderByProperty(this List<dynamic> obj, bool orderByDescending = false, string propertyName = "Id")
        {
            try
            {
                PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
                return orderByDescending ? obj.OrderByDescending(x => propertyInfo.GetValue(x, null)) : obj.OrderBy(x => propertyInfo.GetValue(x, null));
            }
            catch
            {
                return obj;
            }
        }
    }
}