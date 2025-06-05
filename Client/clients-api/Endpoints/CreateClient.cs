namespace clients_api.Endpoints;

public record CreateClientRequest(ClientDto Client);
public record CreateClientResponse(Guid Id);

public class CreateClient : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPost("/Clients", async (CreateClientRequest request, ISender sender) =>
        {
            if (request.Client == null)
            {
                return Results.BadRequest("Request body is null");
            }

            var command = request.Adapt<CreateClientCommand>();
            var result = await sender.Send(command);

            var response = result.Adapt<CreateClientResponse>();

            return Results.Created($"/Clients/{response.Id}", response);
        })
            .WithName("CreateClient")
            .Produces<CreateClientResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Client")
            .WithDescription("Create Client");
        // .RequireAuthorization("authenticated");
    }
}
