namespace BooksCatalog.Infra.Services.Messaging.Events
{
    public record BookCreatedMessage : EventMessage
    {
        public override string QueueName() => "book-created";
    }
}