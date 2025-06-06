using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using technicians_infrastructure.Messaging.Consumers;

namespace technicians_infrastructure;

public static class MessagingServiceRegistration
{
    public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration config)
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumer<CreateTechnicianConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint("create-technician-queue", e =>
                {
                    e.ConfigureConsumer<CreateTechnicianConsumer>(context);
                });
            });
        });

        return services;
    }
}
