using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    public class Receiver
    {
        static int i = 0;
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "BasicTest", durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += Consumer_Received;

                    channel.BasicConsume(queue: "BasicTest", autoAck: true, consumer: consumer);

                    Console.WriteLine("Press [enter] to exit the consumer.");
                }
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.Span;
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"Received the message {i} x {message}");
            i++;
        }
    }
}
