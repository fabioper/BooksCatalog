namespace BooksCatalog.Infra.Services.Messaging.Events
{
    public record GenreCreatedMessage : EventMessage
    {
        public override string QueueName() => "genre-created";
    }
}