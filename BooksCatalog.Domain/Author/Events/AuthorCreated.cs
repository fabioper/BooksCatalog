using System;
using BooksCatalog.Domain.Interfaces.Messaging;

namespace BooksCatalog.Domain.Author.Events
{
    public record AuthorCreated(int AuthorId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "author-created";
    }
}