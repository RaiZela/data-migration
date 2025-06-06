using BuildingBlocks.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_order_domain.Models;

namespace work_order_infrastructure.Messaging.Consumers;


public class CreateWorkOrderConsumer : IConsumer<CreateWorkOrderMessage>
{
    private readonly ApplicationDbContext _db;

    public CreateWorkOrderConsumer(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Consume(ConsumeContext<CreateWorkOrderMessage> context)
    {
        var msg = context.Message;

        var workOrder = WorkOrder.Create(msg.Id, msg.ClientId, msg.TechnicianId, msg.Info, msg.Total, msg.Date);

        _db.WorkOrders.Add(workOrder);
        await _db.SaveChangesAsync();
    }
}