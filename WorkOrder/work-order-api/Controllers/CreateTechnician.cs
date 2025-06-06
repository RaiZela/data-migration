using Carter;
using Mapster;
using MediatR;
using work_order_application.Commands.CreateWorkOrder;
using work_order_application.Dtos;

namespace work_order_api.Controllers;

public record CreateWorkOrderRequest(WorkOrderDto WorkOrder);
public record CreateWorkOrderResponse(Guid Id);

public class CreateWorkOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPost("/WorkOrders", async (CreateWorkOrderRequest request, ISender sender) =>
        {
            if (request.WorkOrder == null)
            {
                return Results.BadRequest("Request body is null");
            }

            var command = request.Adapt<CreateWorkOrderCommand>();
            var result = await sender.Send(command);

            var response = result.Adapt<CreateWorkOrderResponse>();

            return Results.Created($"/WorkOrders/{response.Id}", response);
        })
            .WithName("CreateWorkOrder")
            .Produces<CreateWorkOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create WorkOrder")
            .WithDescription("Create WorkOrder");
        // .RequireAuthorization("authenticated");
    }
}
