namespace BooksCatalog.Core.Interfaces.Messaging
{
    public abstract record ApplicationEvent
    {
        public abstract string QueueName();
    }
}