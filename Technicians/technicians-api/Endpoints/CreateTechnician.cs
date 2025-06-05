using Carter;
using Mapster;
using MediatR;
using technicians_application.Dtos;
using technicians_application.Technicians.Commands.CreateTechnician;

namespace technicians_api.Endpoints;

public record CreateTechnicianRequest(TechnicianDto Technician);
public record CreateTechnicianResponse(Guid Id);

public class CreateTechnician : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPost("/technicians", async (CreateTechnicianRequest request, ISender sender) =>
        {
            if (request.Technician == null)
            {
                return Results.BadRequest("Request body is null");
            }

            var command = request.Adapt<CreateTechnicianCommand>();
            var result = await sender.Send(command);

            var response = result.Adapt<CreateTechnicianResponse>();

            return Results.Created($"/technicians/{response.Id}", response);
        })
            .WithName("CreateTechnician")
            .Produces<CreateTechnicianResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Technician")
            .WithDescription("Create Technician");
        // .RequireAuthorization("authenticated");
    }
}
