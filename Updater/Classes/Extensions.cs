using System.Collections.Generic;

namespace Updater.Classes
{
    public static class Extensions
    {
        public static List<T> ToList<T>(this T[] ts)
        {
            var l = new List<T>();
            foreach (var t in ts)
                l.Add(t);
            return l;
        }
    }
}
