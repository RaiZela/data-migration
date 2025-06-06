using client_infrastructure.Messaging.Consummers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_infrastructure;

public static class MessagingServiceRegistration
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration config)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<CreateClientConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("create-client-queue", e =>
                {
                    e.ConfigureConsumer<CreateClientConsumer>(context);
                });
            });
        });

        return services;
    }
}
