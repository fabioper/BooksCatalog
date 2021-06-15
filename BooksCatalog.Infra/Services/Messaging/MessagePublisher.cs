using System;
using System.Threading.Tasks;
using BooksCatalog.Core.Interfaces;
using BooksCatalog.Core.Interfaces.Messaging;
using MassTransit;

namespace BooksCatalog.Infra.Services.Messaging
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IBus _bus;

        public MessagePublisher(IBus bus) => _bus = bus;

        public async Task Publish(ApplicationEvent message)
        {
            var address = $"queue:{message.QueueName()}";
            var endpoint = await _bus.GetSendEndpoint(new Uri(address));
            await endpoint.Send(message);
        }
    }
}