using System.Collections.Generic;

namespace BasedFunctionalFeatures
{
    public static class StringExt
    {
        public static string JoinBy<T>(this IEnumerable<T> sequence, string separator)
            => string.Join(separator, sequence);

        public static string JoinBy<T>(this IEnumerable<T> sequence, char separator)
            => string.Join(separator, sequence);
    }
}
