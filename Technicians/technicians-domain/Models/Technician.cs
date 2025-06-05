using technicians_domain.Abstractions;
using technicians_domain.Events;

namespace technicians_domain.Models;

public class Technician : Aggregate<Guid>
{
    private Technician()
    { }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }


    public static Technician Create(
        string FirstName,
        string LastName,
        string Email,
        string PhoneNumber)
    {

        //TODO - Validate the input parameters

        var Technician = new Technician
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            PhoneNumber = PhoneNumber
        };


        Technician.AddDomainEvent(new TechnicianCreatedEvent(Technician));
        return Technician;
    }


}
