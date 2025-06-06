using BuildingBlocks.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_infrastructure.Messaging.Publishers;

public class ClientPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public ClientPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync(CreateClientMessage message)
    {
        await _publishEndpoint.Publish(message);
    }
}
