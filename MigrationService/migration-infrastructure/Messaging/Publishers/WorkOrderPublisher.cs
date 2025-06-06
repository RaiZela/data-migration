using BuildingBlocks.Contracts;
using MassTransit;


namespace migration_infrastructure.Messaging.Publishers;

public class WorkOrderPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public WorkOrderPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync(CreateWorkOrderMessage message)
    {
        await _publishEndpoint.Publish(message);
    }
}

