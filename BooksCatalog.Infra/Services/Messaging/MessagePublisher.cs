using System;
using System.Text;
using System.Threading.Tasks;
using BooksCatalog.Domain.Interfaces.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace BooksCatalog.Infra.Services.Messaging
{
    public class MessagePublisher : IMessagePublisher
    {

        public Task Publish(ApplicationEvent message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.ExchangeDeclare(message.QueueName(), ExchangeType.Fanout);
            
            channel.QueueDeclare(message.QueueName(), true, false, false);
            channel.QueueBind(message.QueueName(), message.QueueName(), "");
            
            var serializedMessage = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(serializedMessage);
            
            channel.BasicPublish(message.QueueName(), "", null, body);

            return Task.CompletedTask;
        }
    }
    
}