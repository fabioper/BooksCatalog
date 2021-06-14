namespace BooksCatalog.Infra.Services.Messaging.Events
{
    public record AuthorCreatedMessage : EventMessage
    {
        public override string QueueName() => "author-created";
    }
}