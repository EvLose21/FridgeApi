using FridgeProduct.Auditable.Data;
using FridgeProduct.Auditable.Data.Models;
using FridgeProduct.Auditable.Data.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace FridgeProduct.Auditable.Services
{
    public class Listener : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly IDbContextFactory _dbContextFactory;

        public Listener(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            Reciever();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, eventArgs) =>
            {
                //using var scope = _provider.CreateScope();
                //var context = scope.ServiceProvider.GetRequiredService<RecieveMessageContext>();
                using var context = _dbContextFactory.CreateDbContext();
                
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var content = JsonConvert.DeserializeObject<List<RecieveMessage>>(message);

                //обрабатывать ещё раз, если не обработалось
                
                context.Messages.AddRange(content);
                context.SaveChanges();
                Console.WriteLine($"Message received: {content}");
            };

            _channel.BasicConsume(queue: "fridges", autoAck: true, consumer: consumer);
            
            return Task.CompletedTask;
        }
        /// <summary>
        /// Этот етод создаёт connection factory
        /// </summary>
        public void Reciever()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare("fridges", exclusive: false);
        }
    }
}
