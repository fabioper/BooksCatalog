using System;
using BooksCatalog.Core.Interfaces.Messaging;

namespace BooksCatalog.Core.Publisher.Events
{
    public record PublisherCreated(int PublisherId, DateTime CreatedAt) : ApplicationEvent
    {
        public override string QueueName() => "publisher-created";
    }
}