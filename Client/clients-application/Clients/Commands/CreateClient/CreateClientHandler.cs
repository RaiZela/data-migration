using BuildingBlocks.CQRS;
using clients_application.Data.Intefaces;
using clients_application.Dtos;
using clients_domain.Models;

namespace clients_application.Clients.Commands.CreateClient;

public class CreateClientHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateClientCommand, CreateClientResult>
{
    public async Task<CreateClientResult> Handle(CreateClientCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var Client = CreateNewClient(command.Client);

            dbContext.Clients.Add(Client);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateClientResult(Client.Id);

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private Client CreateNewClient(ClientDto ClientDto)
    {

        var newClient = Client.Create(
         Guid.NewGuid(),
         ClientDto.FirstName,
         ClientDto.LastName,
         ClientDto.Email,
         ClientDto.PhoneNumber);

        newClient.Id = Guid.NewGuid();

        return newClient;
    }
}

