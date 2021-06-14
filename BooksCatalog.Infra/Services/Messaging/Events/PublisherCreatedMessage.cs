namespace BooksCatalog.Infra.Services.Messaging.Events
{
    public record PublisherCreatedMessage : EventMessage
    {
        public override string QueueName() => "publisher-created";
    }
}