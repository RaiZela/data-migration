using clients_domain.Abstractions;
using clients_domain.Events;

namespace clients_domain.Models;

public class Client : Aggregate<Guid>
{
    private Client()
    { }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }


    public static Client Create(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber)
    {

        //TODO - Validate the input parameters

        var client = new Client
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber
        };


        client.AddDomainEvent(new ClientCreatedEvent(client));
        return client;
    }


}
