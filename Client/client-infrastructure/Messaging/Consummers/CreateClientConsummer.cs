using BuildingBlocks.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client_infrastructure.Messaging.Consummers;

public class CreateClientConsumer : IConsumer<CreateClientMessage>
{
    private readonly ApplicationDBContext _db;

    public CreateClientConsumer(ApplicationDBContext db)
    {
        _db = db;
    }

    public async Task Consume(ConsumeContext<CreateClientMessage> context)
    {
        var msg = context.Message;

        var client =  Client.Create(msg.Id,msg.FirstName,msg.LastName);

        _db.Clients.Add(client);
        await _db.SaveChangesAsync();
    }
}
