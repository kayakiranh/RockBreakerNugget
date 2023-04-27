using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
        public static List<object> OrderByProperty(this object obj, bool orderByDescending = false, string propertyName = "Id")
        {
            try
            {
                List<object> collection = (obj as IEnumerable<object>).Cast<object>().ToList();
                return orderByDescending ? collection.OrderByDescending(p => p.GetType().GetProperty(propertyName).GetValue(p, null)).ToList() : collection.OrderBy(p => p.GetType().GetProperty(propertyName).GetValue(p, null)).ToList();
            }
            catch
            {
                return new List<object>();
            }
        }
    }
}