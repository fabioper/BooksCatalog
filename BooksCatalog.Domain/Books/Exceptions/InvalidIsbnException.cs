using System;

namespace BooksCatalog.Domain.Books.Exceptions
{
    public class InvalidIsbnException : ArgumentException
    {
        public InvalidIsbnException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}