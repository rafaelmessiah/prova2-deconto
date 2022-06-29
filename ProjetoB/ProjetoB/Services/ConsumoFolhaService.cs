using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using ProjetoB.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ProjetoB.Services
{
    public class ConsumoFolhaService: BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        private const string FILA = "folhas";
        public ConsumoFolhaService(IServiceProvider serviceProvider)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: FILA,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            
            consumer.Received += (model, message) =>
            {
                var body = message.Body.ToArray();
                var folha = JsonSerializer.Deserialize<Folha>(body);

                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<FolhaService>();

                    service.Cadastrar(folha);
                }
            };
            
            _channel.BasicConsume(queue: FILA,
                                autoAck: true,
                                consumer: consumer);
            return Task.CompletedTask;
        }
    }
}
