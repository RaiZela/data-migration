using BuildingBlocks.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration_infrastructure.Messaging.Publishers;

public class TechnicianPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public TechnicianPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync(CreateTechnicianMessage message)
    {
        await _publishEndpoint.Publish(message);
    }
}
