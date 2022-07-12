namespace Helpers
{
    public static class ComparisonHelpers
    {
    #region Null checks
        public static bool IsNull<T>(this T type)
        {
            return type == null;
        }
        public static bool NotNull<T>(this T type)
        {
            return type != null;
        }
    #endregion
        
    #region Numbers
        public static bool IsBetween(this float number, float lower, float upper)
        {   // for floats
            return number > lower && number < upper;
        }
        public static bool IsBetween(this int number, int lower, int upper)
        {   // for ints
            return number > lower && number < upper;
        }
    #endregion
    }
}