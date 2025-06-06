using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_order_infrastructure.Messaging.Consumers;

namespace work_orders_infrastructure;

public static class MessagingServiceRegistration
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration config)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<CreateWorkOrderConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("create-WorkOrder-queue", e =>
                {
                    e.ConfigureConsumer<CreateWorkOrderConsumer>(context);
                });
            });
        });

        return services;
    }
}
