using BuildingBlocks.CQRS;
using technicians_application.Data.Intefaces;
using technicians_application.Dtos;
using technicians_domain.Models;

namespace technicians_application.Technicians.Commands.CreateTechnician;

public class CreateTechnicianHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateTechnicianCommand, CreateTechnicianResult>
{
    public async Task<CreateTechnicianResult> Handle(CreateTechnicianCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var Technician = CreateNewTechnician(command.Technician);

            dbContext.Technicians.Add(Technician);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateTechnicianResult(Technician.Id);

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private Technician CreateNewTechnician(TechnicianDto TechnicianDto)
    {

        var newTechnician = Technician.Create(
         TechnicianDto.FirstName,
         TechnicianDto.LastName,
         TechnicianDto.Email,
         TechnicianDto.PhoneNumber);

        newTechnician.Id = Guid.NewGuid();

        return newTechnician;
    }
}

