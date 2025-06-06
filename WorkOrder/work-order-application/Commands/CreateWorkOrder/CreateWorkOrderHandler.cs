using BuildingBlocks.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_order_application.Data.Interfaces;
using work_order_application.Dtos;
using work_order_domain.Models;

namespace work_order_application.Commands.CreateWorkOrder;

public class CreateWorkOrderHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateWorkOrderCommand, CreateWorkOrderResult>
{
    public async Task<CreateWorkOrderResult> Handle(CreateWorkOrderCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var WorkOrder = CreateNewWorkOrder(command.WorkOrder);

            dbContext.WorkOrders.Add(WorkOrder);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateWorkOrderResult(WorkOrder.Id);

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private WorkOrder CreateNewWorkOrder(WorkOrderDto WorkOrderDto)
    {

        var newWorkOrder = WorkOrder.Create(
            WorkOrderDto.Id,
            WorkOrderDto.ClientId,
            WorkOrderDto.TechnicianId,
            WorkOrderDto.Info,
            WorkOrderDto.Total,
            WorkOrderDto.Date
         );

        newWorkOrder.Id = Guid.NewGuid();

        return newWorkOrder;
    }
}
