using System;
using System.Linq;

namespace BasedFunctionalFeatures
{
    public static class PrintExt
    {
        private static string ToString(object obj) =>
            obj switch {
                string s => s,
                object[] objects => objects.Select(ToString).JoinBy(", "),
                _ => obj.ToString()
            };

        public static void Print(this object obj)
            => Console.WriteLine(ToString(obj));
    }
}
