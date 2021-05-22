using System;

namespace BooksCatalog.Core.Books.Exceptions
{
    public class InvalidIsbnException : ArgumentException
    {
        public InvalidIsbnException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}