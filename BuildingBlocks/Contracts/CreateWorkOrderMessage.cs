namespace BuildingBlocks.Contracts;

public record CreateWorkOrderMessage(
    Guid Id, 
    Guid ClientId, 
    Guid TechnicianId, 
    string Info, 
    decimal Total, 
    DateTime Date);

