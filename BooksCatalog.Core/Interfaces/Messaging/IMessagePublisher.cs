using System.Threading.Tasks;

namespace BooksCatalog.Core.Interfaces.Messaging
{
    public interface IMessagePublisher
    {
        Task Publish(ApplicationEvent message);
    }
}