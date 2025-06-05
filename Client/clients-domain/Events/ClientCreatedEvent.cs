using clients_domain.Abstractions;
using clients_domain.Models;

namespace clients_domain.Events;

public record ClientCreatedEvent(Client Client) : IDomainEvent;
