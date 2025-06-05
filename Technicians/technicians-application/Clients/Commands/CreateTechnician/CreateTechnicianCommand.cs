using technicians_application.Dtos;
using FluentValidation;
using BuildingBlocks.CQRS;

namespace technicians_application.Technicians.Commands.CreateTechnician;

public record CreateTechnicianCommand(TechnicianDto Technician)
    : ICommand<CreateTechnicianResult>;


public record CreateTechnicianResult(Guid Id);

public class CreateTechnicianCommandValidator : AbstractValidator<CreateTechnicianCommand>
{
    public CreateTechnicianCommandValidator()
    {
        RuleFor(x => x.Technician.FirstName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20)
            .WithMessage("FirstName is required!");

        RuleFor(x => x.Technician.LastName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20)
            .WithMessage("LastName is required!");

        RuleFor(x => x.Technician.Email).NotNull().NotEmpty().WithMessage("Email is required!"); //TODO add email format validation

        RuleFor(x => x.Technician.PhoneNumber).NotNull().NotEmpty().WithMessage("PhoneNumber is required!"); //TODO add phone number format validation
    }
}
