using BuildingBlocks.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using technicians_domain.Models;

namespace technicians_infrastructure.Messaging.Consumers;

public class CreateTechnicianConsumer : IConsumer<CreateTechnicianMessage>
{
    private readonly ApplicationDbContext _db;

    public CreateTechnicianConsumer(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task Consume(ConsumeContext<CreateTechnicianMessage> context)
    {
        var msg = context.Message;

        var technician = Technician.Create(msg.Id, msg.FirstName, msg.LastName);

        _db.Technicians.Add(technician);
        await _db.SaveChangesAsync();
    }
}