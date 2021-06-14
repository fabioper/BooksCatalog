using System.Threading.Tasks;
using BooksCatalog.Infra.Services.Messaging.Events;

namespace BooksCatalog.Infra.Services.Contracts
{
    public interface IEventBus
    {
        Task Publish(EventMessage message);
    }
}