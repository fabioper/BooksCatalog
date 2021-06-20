using System;
using BooksCatalog.Domain.Interfaces.Messaging;

namespace BooksCatalog.Domain.Publishers.Events
{
    public record PublisherCreated(int PublisherId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "publisher-created";
    }
}