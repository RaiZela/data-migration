using BuildingBlocks.CQRS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using work_order_application.Dtos;

namespace work_order_application.Commands.CreateWorkOrder;

public record CreateWorkOrderCommand(WorkOrderDto WorkOrder)
    : ICommand<CreateWorkOrderResult>;


public record CreateWorkOrderResult(Guid Id);

public class CreateWorkOrderCommandValidator : AbstractValidator<CreateWorkOrderCommand>
{
    public CreateWorkOrderCommandValidator()
    {
       
    }
}
