using System;
using System.Threading.Tasks;
using BooksCatalog.Infra.Services.Contracts;
using BooksCatalog.Infra.Services.Messaging.Events;
using MassTransit;

namespace BooksCatalog.Infra.Services.Messaging
{
    public class EventBus : IEventBus
    {
        private readonly IBus _bus;

        public EventBus(IBus bus)
        {
            _bus = bus;
        }

        public async Task Publish(EventMessage message)
        {
            var address = $"queue:{message.QueueName()}";
            var endpoint = await _bus.GetSendEndpoint(new Uri(address));
            await endpoint.Send(message);
        }
    }
}