using System;
using BooksCatalog.Core.Interfaces.Messaging;

namespace BooksCatalog.Core.Author.Events
{
    public record AuthorCreated(int AuthorId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "author-created";
    }
}