using Cryptocop.Software.API.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class QueueService : IQueueService, IDisposable
    {
        private readonly IModel _channel;
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly string _exchangeName;

        public QueueService(IConfiguration configuration)
        {
            _configuration = configuration;

            try
            {
                var messageBrokerSection = configuration.GetSection("MessageBroker");
                _exchangeName = messageBrokerSection.GetSection("ExchangeName").Value;
                var host = messageBrokerSection.GetSection("Host").Value;

                var factory = new ConnectionFactory
                {
                    Uri = new Uri(messageBrokerSection.GetSection("ConnectionString").Value),
                    HostName = host,
                    Port = 5672
                };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(_exchangeName, ExchangeType.Direct, true);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void PublishMessage(string routingKey, object body)
        {
            var messageBrokerSection = _configuration.GetSection("MessageBroker");
           
            _channel.BasicPublish(
                exchange: _exchangeName,
                routingKey,
                mandatory: true,
                basicProperties: null,
                body: ConvertJsonToBytes(body));
        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
        
        private static byte[] ConvertJsonToBytes(object obj) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
    }
}