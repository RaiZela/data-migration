using technicians_domain.Abstractions;
using technicians_domain.Models;

namespace technicians_domain.Events;

public record TechnicianUpdatedEvent(Technician Technician) : IDomainEvent;