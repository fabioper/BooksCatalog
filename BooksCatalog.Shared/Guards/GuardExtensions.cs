using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BooksCatalog.Shared.Guards
{
    public static class GuardExtensions
    {
        public static void Null<T>(this IGuardClause clause, T input, string parameterName)
        {
            if (input is null)
                throw new ArgumentNullException(parameterName);

            if (string.IsNullOrEmpty(input.ToString()))
                throw new ArgumentException(parameterName);
        }

        public static void NullOrEmpty(this IGuardClause clause, string input, string parameterName)
        {
            Guard.Against.Null(input, parameterName);

            if (string.IsNullOrEmpty(input))
                throw new ArgumentException(parameterName);
        }

        public static void NullOrEmpty<T>(this IGuardClause clause, List<T> input, string parameterName)
        {
            Guard.Against.Null(input, parameterName);

            if (!input.Any())
                throw new ArgumentException(parameterName);
        }

        public static void NegativeOrZero(this IGuardClause clause, int input, string parameterName)
        {
            if (input <= 0)
                throw new ArgumentException($"{parameterName} cannot be negative or less than 0", parameterName);
        }
    }
}