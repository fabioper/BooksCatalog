using System.Threading.Tasks;

namespace BooksCatalog.Domain.Interfaces.Messaging
{
    public interface IMessagePublisher
    {
        Task Publish(ApplicationEvent message);
    }
}