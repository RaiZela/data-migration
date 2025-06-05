using technicians_domain.Abstractions;
using technicians_domain.Models;

namespace technicians_domain.Events;

public record TechnicianCreatedEvent(Technician Technician) : IDomainEvent;
