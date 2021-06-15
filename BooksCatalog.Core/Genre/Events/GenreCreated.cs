using System;
using BooksCatalog.Core.Interfaces.Messaging;

namespace BooksCatalog.Core.Genre.Events
{
    public record GenreCreated(int GenreId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "genre-created";
    }
}