using MicroServicesRabbitMQ.Domain.Core.Bus;
using MicroServicesRabbitMQ.Infrastructure.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace MicroServicesRabbitMQ.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}
