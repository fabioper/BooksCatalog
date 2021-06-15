namespace BooksCatalog.Domain.Interfaces.Messaging
{
    public abstract record ApplicationEvent
    {
        public abstract string QueueName();
    }
}