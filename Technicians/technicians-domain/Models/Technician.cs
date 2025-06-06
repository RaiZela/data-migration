using technicians_domain.Abstractions;
using technicians_domain.Events;

namespace technicians_domain.Models;

public class Technician : Aggregate<Guid>
{
    private Technician()
    { }

    public string FirstName { get; set; }
    public string LastName { get; set; }
 


    public static Technician Create(
        Guid Id,
        string FirstName,
        string LastName)
    {

        //TODO - Validate the input parameters

        var Technician = new Technician
        {
            Id = Id==Guid.Empty ? Guid.NewGuid() : Id,
            FirstName = FirstName,
            LastName = LastName
        };


        Technician.AddDomainEvent(new TechnicianCreatedEvent(Technician));
        return Technician;
    }


}
