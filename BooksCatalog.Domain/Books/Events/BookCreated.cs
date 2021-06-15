using System;
using BooksCatalog.Domain.Interfaces.Messaging;

namespace BooksCatalog.Domain.Books.Events
{
    public record BookCreated(int BookId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "book-created";
    }
}