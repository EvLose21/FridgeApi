
using FridgeProduct.Auditable.Data.Models;
using FridgeProduct.Auditable.Data.Repositories.Abstracts;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace FridgeProduct.Auditable.Services
{
    public class MesssageReciever : IMessageReciever
    {
        private readonly IRecieveMessageRepository _repository;
        public MesssageReciever(IRecieveMessageRepository repository)
        {
            _repository = repository;
        }
        public void Reciever()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("fridges", exclusive: false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var newmes = new RecieveMessage
                {
                    Message = message
                };

                _repository.CreateMessage(newmes);
                _repository.Save();
                Console.WriteLine($"Message received: {message}");
            };

            channel.BasicConsume(queue: "fridges", autoAck: true, consumer: consumer);
        }
    }
}
