using Newtonsoft.Json;
using OnlineStore.Domain.Interfaces;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Infrastructure.Messaging
{
	public class RabbitMQProducer : IMessageProducer
	{
		private readonly IConnection _connection;
		private readonly IModel _channel;

		public RabbitMQProducer(RabbitMQSettings rabbitMQSettings)
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
			try
			{
				_connection = factory.CreateConnection();
				_channel = _connection.CreateModel();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"RabbitMQ connection error: {ex.Message}");
				throw;
			}
		}

		public void SendMessage(string message)
		{
			_channel.QueueDeclare(queue: "pedidoQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
			var body = Encoding.UTF8.GetBytes(message);
			_channel.BasicPublish(exchange: "", routingKey: "pedidoQueue", basicProperties: null, body: body);
			Console.WriteLine(" [x] Sent {0}", message);
		}
	}
}
