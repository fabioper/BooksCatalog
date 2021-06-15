using System;
using BooksCatalog.Core.Interfaces.Messaging;

namespace BooksCatalog.Core.Books.Events
{
    public record BookCreated(int BookId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "book-created";
    }
}