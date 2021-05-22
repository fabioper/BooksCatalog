using System;

namespace BooksCatalog.Shared
{
    public static class GuardExtensions
    {
        public static void NullOrEmpty<T>(this IGuardClause clause, T input, string parameterName)
        {
            if (input is null)
                throw new ArgumentNullException(parameterName);

            if (string.IsNullOrEmpty(input.ToString()))
                throw new ArgumentException(parameterName);
        }

        public static void NegativeOrZero(this IGuardClause clause, int input, string parameterName)
        {
            if (input <= 0)
                throw new ArgumentException($"{parameterName} cannot be negative or less than 0", parameterName);
        }
    }
}