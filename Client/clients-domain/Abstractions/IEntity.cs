namespace clients_domain.Abstractions;

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}
public interface IEntity
{
    //public DateTime? CreatedAt { get; set; }
    //public Guid CreatedByUserId { get; set; }
    //public DateTime? LastModified { get; set; }
    //public Guid LastModifiedByUserId { get; set; }
}
