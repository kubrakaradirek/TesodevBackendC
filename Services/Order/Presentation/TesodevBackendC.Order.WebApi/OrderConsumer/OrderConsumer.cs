using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;
using System.Text;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderLogCommands;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderLogHandlers;

namespace TesodevBackendC.Order.WebApi.OrderConsumer
{
    public class OrderConsumer
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public OrderConsumer(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public void Start()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "OrderQ",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var handler = scope.ServiceProvider.GetRequiredService<CreateOrderLogCommandHandler>();

                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received {0}", message);

                    var command = new CreateOrderLogCommand(message, DateTime.Now);
                    await handler.Handle(command);
                }
            };
            channel.BasicConsume(queue: "OrderQ", autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
