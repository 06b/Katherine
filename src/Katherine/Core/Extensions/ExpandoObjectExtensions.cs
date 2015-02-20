using System.Collections.Generic;
using System.Dynamic;

namespace Katherine.Core.Extensions
{
    /// <summary>
    /// Check to see if ExpandoObject contains a definition.
    /// Source: http://stackoverflow.com/a/11738271
    /// </summary>
    public static class ExpandoObjectExtensions
    {
        public static bool HasValue(this object val, string key)
        {
            var expando = val as ExpandoObject;
            if (expando == null) return false;

            return ((IDictionary<string, object>)expando).ContainsKey(key);
        }
    }
}