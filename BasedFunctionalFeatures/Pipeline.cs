using System;

namespace BasedFunctionalFeatures
{
    public static class Pipeline
    {
        public static TOut As<TIn, TOut>(this TIn self, Func<TIn, TOut> @as)
            => @as(self);
    }
}
