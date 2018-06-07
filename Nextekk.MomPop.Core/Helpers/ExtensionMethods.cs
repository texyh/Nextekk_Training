using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Nextekk.MomPop.Core.Helpers
{
    public static class ExtensionMethods
    {
        public static bool IsNull<T>(this T source)
        {
            return source == null;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Count() == 0;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source.IsNullOrEmpty())
            {
                return;
            }

            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}
