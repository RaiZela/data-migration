using BuildingBlocks.CQRS;
using clients_application.Dtos;
using FluentValidation;

namespace clients_application.Clients.Commands.CreateClient;

public record CreateClientCommand(ClientDto Client)
    : ICommand<CreateClientResult>;


public record CreateClientResult(Guid Id);

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {
        RuleFor(x => x.Client.FirstName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20)
            .WithMessage("FirstName is required!");

        RuleFor(x => x.Client.LastName).NotEmpty().NotNull().MinimumLength(2).MaximumLength(20)
            .WithMessage("LastName is required!");

        RuleFor(x => x.Client.Email).NotNull().NotEmpty().WithMessage("Email is required!"); //TODO add email format validation

        RuleFor(x => x.Client.PhoneNumber).NotNull().NotEmpty().WithMessage("PhoneNumber is required!"); //TODO add phone number format validation
    }
}
