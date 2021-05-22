using BooksCatalog.Core.Books.Exceptions;
using BooksCatalog.Shared;

namespace BooksCatalog.Core.Books.Guards
{
    public static class BookGuardsExtensions
    {
        public static void InvalidIsbn(this IGuardClause clause, string isbn)
        {
            if (!IsValidIsbn(isbn))
                throw new InvalidIsbnException($"ISBN <{isbn}> is not valid", isbn);
        }

        private static bool IsValidIsbn(string isbn)
        {
            var n = isbn.Length;
            if (n != 10)
                return false;
 
            var sum = 0;
            for (var i = 0; i < 9; i++)
            {
                var digit = isbn[i] - '0';
             
                if (0 > digit || 9 < digit)
                    return false;
                 
                sum += (digit * (10 - i));
            }
 
            var last = isbn[9];
            if (last != 'X' && (last < '0'
                                || last > '9'))
                return false;
            
            sum += last == 'X' ? 10 :
                last - '0';
            
            return sum % 11 == 0;
        }
    }
}