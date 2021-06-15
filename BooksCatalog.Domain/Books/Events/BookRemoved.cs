using BooksCatalog.Domain.Interfaces.Messaging;

namespace BooksCatalog.Domain.Books.Events
{
    public record BookRemoved(int BookId) : ApplicationEvent
    {
        public override string QueueName() => "book-removed";
    }
}