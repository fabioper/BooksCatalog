using System;
using BooksCatalog.Domain.Interfaces.Messaging;

namespace BooksCatalog.Domain.Genres.Events
{
    public record GenreCreated(int GenreId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "genre-created";
    }
}