namespace BooksCatalog.Infra.Services.Messaging.Events
{
    public abstract record EventMessage
    {
        public abstract string QueueName();
    }
}