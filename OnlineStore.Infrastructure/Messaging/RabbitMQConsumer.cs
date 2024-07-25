using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;


namespace OnlineStore.Infrastructure.Messaging
{
	public class RabbitMQConsumer : IHostedService
	{
		private readonly IConnection _connection;
		private readonly IModel _channel;

		public RabbitMQConsumer(RabbitMQSettings rabbitMQSettings)
		{
			var factory = new ConnectionFactory()
			{
				//HostName = "http://localhost",
				//Port = 5672,
				//UserName = "gerfor",
				//Password = "Gerfor2023+"
				HostName = rabbitMQSettings.HostName,
				Port = rabbitMQSettings.Port,
				UserName = rabbitMQSettings.UserName,
				Password = rabbitMQSettings.Password
			};
			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_channel.QueueDeclare(queue: "pedidoQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
			var consumer = new EventingBasicConsumer(_channel);
			consumer.Received += (model, ea) =>
			{
				var body = ea.Body.ToArray();
				var message = Encoding.UTF8.GetString(body);
				Console.WriteLine(" [x] Received {0}", message);
				// Procesar el mensaje
			};
			_channel.BasicConsume(queue: "pedidoQueue", autoAck: true, consumer: consumer);

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_channel.Close();
			_connection.Close();
			return Task.CompletedTask;
		}
	}
}
